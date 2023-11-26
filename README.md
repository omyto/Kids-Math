# Kids-Math

A Windows desktop math game for children, migrated from Windows Phone 8 to WPF.

## Requirements

- Windows 10 or Windows 11.
- Visual Studio 2022 17.8+, with **.NET desktop development** and the **.NET 8 SDK / targeting pack** installed.
- To run a built executable, install the .NET 8 Desktop Runtime, or publish a self-contained build.

## Build and run

Open `Math4Kid.sln`, select `Math4Kid` as the startup project and press F5.

From a terminal:

```powershell
dotnet build Math4Kid.sln
dotnet run --project Math4Kid/Math4Kid.csproj
```

The game preserves its 800 x 480 landscape canvas and scales to the window. Use the toolbar Home / Back buttons or Alt+Left to navigate. Mouse clicks and Windows touch input activate the games. Windows Phone Store review integration has been removed.

All artwork is embedded in the application. Audio files are copied into `Assets/Sounds` alongside the executable; keep that directory when distributing the build.

## Verification

```powershell
dotnet run --project tests/WpfSmoke/WpfSmoke.csproj
dotnet build Math4Kid.sln -c Release
```

The Windows STA smoke runner opens a temporary window, exercises all eight menu activities, correct and incorrect answers, completion and return navigation, ordering and pair games, number wraparound and resizing. It saves a menu render to `artifacts/wpf-menu.png`. Audio file deployment is checked; audible playback should also be checked manually on the destination PC.

The old phone deployment manifests in `Math4Kid/Properties` are historical files and are not used by WPF. The original version remains in Git history on `main`.
