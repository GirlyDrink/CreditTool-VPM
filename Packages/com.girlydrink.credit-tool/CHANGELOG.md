# Changelog

## [1.0.4] - 2025-06-13
### Fixed
- Replaced `DistinctBy` with `Distinct` using a custom `IEqualityComparer` in `CreditToolWindow.cs` to resolve CS1061 error, ensuring compatibility with Unity 2022.3's .NET 4.x.

## [1.0.3] - 2025-06-13
### Added
- Added `authorStoreLink` field to `CreditComponent` for author store or profile URLs.
- Added toggles in `CreditToolWindow` to include/exclude `assetLink` and `authorStoreLink` in the output.
- Updated output format to support both author store and asset links (e.g., `Author1 (StoreLink): Asset1 (AssetLink)`).

### Changed
- Updated `README.md` and `package.json` to reflect new fields and toggle options.

## [1.0.2] - 2025-06-13
### Changed
- Moved the Credit Tool menu item from `Tools/Credit Tool` to `Tools/GirlyDrink's Tools/Credit Tool`.
- Updated `README.md` and `package.json` to reflect the new menu path.

## [1.0.1] - 2025-06-13
### Changed
- Updated package name to `com.girlydrink.credit-tool` and username to `GirlyDrink`.
- Updated namespaces to `GirlyDrink.CreditTool` and `GirlyDrink.CreditTool.Editor`.
- Updated assembly definitions to `GirlyDrink.CreditTool` and `GirlyDrink.CreditTool.Editor`.
- Updated GitHub repository URLs to `https://github.com/GirlyDrink/credit-tool`.

## [1.0.0] - 2025-06-12
### Added
- Initial release of Credit Tool.
- `CreditComponent` implementing `IEditorOnly` for adding author and single asset information to prefabs in the Editor.
- Editor window under `Tools/Credit Tool` to scan a GameObject hierarchy and display a formatted credit list in a textbox, merging assets by author.
- VPM package configuration for VRChat compatibility.

### Fixed
- Added missing `using Tchoutchawn.CreditTool;` directive in `CreditToolWindow.cs` to resolve `CreditComponent` reference error.
- Added assembly definition files (`Tchoutchawn.CreditTool.asmdef` and `Tchoutchawn.CreditTool.Editor.asmdef`) to ensure Editor scripts can reference runtime scripts.
- Replaced clipboard copy with a scrollable textbox for credit list output.
- Made `CreditComponent` implement `IEditorOnly` with `VRC.SDKBase` to ensure it is stripped from VRChat builds.