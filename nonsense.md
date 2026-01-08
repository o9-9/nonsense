# Explore nonsense Utility files and build instructions
_Exported on 11/28/2025 at 17:26:08 GMT+3 from Cursor (2.0.69)_

---

**User**

nonsense Utility is open source, and I've Clone and modified it.



I need you to explore all the files inside nonsense folder to understand how it works and provide me with detailed instructions. I also need you to tell me how to build "nonsense.Installer.exe".@nonsense 

---

**Cursor**


Exploring the project structure and key files to understand how it works and how to build the installer.



Reviewing project files to understand the architecture:



Checking for prerequisites and additional configuration:



## **Project Overview**

**nonsense** is a Windows enhancement utility built with C# and WPF. It uses a clean architecture with three layers:

1. **nonsense.Core** — Domain models, interfaces, and abstractions
2. **nonsense.Infrastructure** — Service implementations
3. **nonsense.WPF** — WPF UI layer

### **Key Technologies:**
- **.NET 9.0** (Windows Desktop)
- **WPF** (Windows Presentation Foundation)
- **MVVM** (Model-View-ViewModel) with CommunityToolkit.Mvvm
- **Dependency Injection** (Microsoft.Extensions.DependencyInjection)
- **Inno Setup** (for installer creation)

---

## **How the Application Works**

### **1. Architecture & Dependency Injection**

The app uses a composition root pattern (`CompositionRoot.cs`) that:
- Registers services in dependency order (Core → Infrastructure → Domain → UI)
- Uses Microsoft.Extensions.Hosting for service lifecycle
- Implements MVVM with ViewModels registered in DI

### **2. Application Startup Flow** (`App.xaml.cs`)

1. Single instance check (mutex)
2. Admin privilege check (restarts with elevation if needed)
3. Host creation and service initialization
4. Loading window display
5. Data preloading (settings, backups, migrations)
6. Main window display

### **3. Main Features**

- **Software & Apps**: Manage Windows apps and install external apps via WinGet
- **Optimize**: System optimizations, privacy settings, power plans
- **Customize**: Theme, taskbar, Start menu, Explorer customizations
- **Advanced Tools**: WIMUtil for ISO creation, autounattend.xml generation

---

## **How to Build `nonsense.Installer.exe`**

### **Prerequisites**

1. **.NET 9.0 SDK**
   - Download from: https://dotnet.microsoft.com/download/dotnet/9.0
   - Verify: `dotnet --version`

2. **Inno Setup 6**
   - Download from: https://jrsoftware.org/isdl.php
   - Install to default location: `C:\Program Files (x86)\Inno Setup 6\`
   - Or update the path in `build-and-package.ps1` (line 287)

3. **.NET 9.0 Runtime Installer** (for the installer package)
   - Download: `windowsdesktop-runtime-9.0.10-win-x64.exe`
   - Place it in: `extras\prerequisites\`
   - Create the folder if it doesn't exist:
     ```powershell
     New-Item -ItemType Directory -Path "extras\prerequisites" -Force
     ```
   - Download URL: https://dotnet.microsoft.com/download/dotnet/9.0

4. **Optional: Code Signing Certificate** (for signing the executable)
   - Required only if you want to sign the application
   - Must be installed in Windows Certificate Store (Current User → Personal)

### **Build Steps**

#### **Method 1: Using the Automated Build Script (Recommended)**

1. Open PowerShell in the project root directory
2. Navigate to the extras folder:
   ```powershell
   cd extras
   ```
3. Run the build script:
   ```powershell
   .\build-and-package.ps1
   ```
   Or with options:
   ```powershell
   # With version specified
   .\build-and-package.ps1 -Version "25.12.01"
   
   # With code signing
   .\build-and-package.ps1 -SignApplication
   
   # Beta version
   .\build-and-package.ps1 -Beta
   ```

4. The script will:
   - Clean the solution
   - Build the solution
   - Publish the application (Release, win-x64)
   - Optionally sign the executable
   - Update the Inno Setup script with correct paths
   - Compile the installer using Inno Setup
   - Optionally sign the installer

5. Output location: `installer-output\nonsense.Installer.exe`

#### **Method 2: Manual Build Process**

1. **Build the Solution:**
   ```powershell
   dotnet clean "src\nonsense.WPF\nonsense.WPF.csproj" --configuration Release
   dotnet build "src\nonsense.WPF\nonsense.WPF.csproj" --configuration Release
   ```

2. **Publish the Application:**
   ```powershell
   dotnet publish "src\nonsense.WPF\nonsense.WPF.csproj" `
     --configuration Release `
     --runtime win-x64 `
     --self-contained false `
     -p:PublishSingleFile=false `
     -p:PublishReadyToRun=true
   ```

3. **Prepare Prerequisites:**
   - Ensure `extras\prerequisites\windowsdesktop-runtime-9.0.10-win-x64.exe` exists

4. **Update Inno Setup Script:**
   - Open `extras\nonsense.Installer.iss` in Inno Setup Compiler
   - Update paths if needed (lines 39, 43, 45, 189-211)
   - Update version (line 5): `#define MyAppVersion "25.12.01"`

5. **Compile the Installer:**
   - Open Inno Setup Compiler
   - Load `extras\nonsense.Installer.iss`
   - Click "Build" → "Compile"
   - Or use command line:
     ```powershell
     & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "extras\nonsense.Installer.iss"
     ```

6. **Output:** `installer-output\nonsense.Installer.exe`

### **Important Notes:**

1. **Path Configuration**: The Inno Setup script (`nonsense.Installer.iss`) has hardcoded paths:
   - Line 39: `LicenseFile=C:\nonsense\LICENSE.txt`
   - Line 43: `OutputDir=C:\nonsense\installer-output`
   - Line 45: `SetupIconFile=C:\nonsense\src\nonsense.WPF\Resources\AppIcons\nonsense.ico`
   - Lines 189-211: Source paths for published files
   
   The `build-and-package.ps1` script automatically updates these paths, so use it if your project is not at `C:\nonsense\`.

2. **Version Management**: The build script updates the version in:
   - `nonsense.WPF.csproj` (Version, FileVersion, AssemblyVersion, InformationalVersion)
   - `nonsense.Installer.iss` (MyAppVersion)

3. **Installer Features**:
   - Supports both regular and portable installations
   - Includes .NET 9.0 Runtime installer
   - Creates file associations for `.nonsense` files
   - Optional desktop/Start menu shortcuts
   - Preserves user data during updates

4. **Troubleshooting**:
   - If Inno Setup is not found, check the path in `build-and-package.ps1` (line 287-294)
   - If prerequisites are missing, ensure `extras\prerequisites\windowsdesktop-runtime-9.0.10-win-x64.exe` exists
   - If paths are incorrect, run the build script which auto-updates them

---

## **Project Structure Summary**

```
nonsense/
├── src/
│   ├── nonsense.Core/          # Domain models, interfaces, enums
│   ├── nonsense.Infrastructure/ # Service implementations
│   └── nonsense.WPF/           # WPF UI, ViewModels, Views
├── extras/
│   ├── build-and-package.ps1   # Automated build script
│   ├── nonsense.Installer.iss  # Inno Setup installer script
│   └── prerequisites/          # .NET Runtime installer (not in git)
├── installer-output/           # Build output (not in git)
└── nonsense.sln                # Visual Studio solution file
```

---

The build script automates most steps. Ensure prerequisites are installed and the prerequisites folder contains the .NET Runtime installer, then run the script.

```powershell
     New-Item -ItemType Directory -Path "extras\prerequisites" -Force
```

```powershell
   cd extras
```

```powershell
   .\build-and-package.ps1
```

```powershell
   # With version specified
   .\build-and-package.ps1 -Version "25.12.01"
   
   # With code signing
   .\build-and-package.ps1 -SignApplication
   
   # Beta version
   .\build-and-package.ps1 -Beta
```

```powershell
   dotnet clean "src\nonsense.WPF\nonsense.WPF.csproj" --configuration Release
   dotnet build "src\nonsense.WPF\nonsense.WPF.csproj" --configuration Release
```

```powershell
   dotnet publish "src\nonsense.WPF\nonsense.WPF.csproj" `
     --configuration Release `
     --runtime win-x64 `
     --self-contained false `
     -p:PublishSingleFile=false `
     -p:PublishReadyToRun=true
```

```powershell
     & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "extras\nonsense.Installer.iss"
```

```plaintext
nonsense/
├── src/
│   ├── nonsense.Core/          # Domain models, interfaces, enums
│   ├── nonsense.Infrastructure/ # Service implementations
│   └── nonsense.WPF/           # WPF UI, ViewModels, Views
├── extras/
│   ├── build-and-package.ps1   # Automated build script
│   ├── nonsense.Installer.iss  # Inno Setup installer script
│   └── prerequisites/          # .NET Runtime installer (not in git)
├── installer-output/           # Build output (not in git)
└── nonsense.sln                # Visual Studio solution file
```

