# Changelog

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