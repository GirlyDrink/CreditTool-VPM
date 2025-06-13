# Credit Tool for VRChat

A Unity tool for VRChat creators to manage and compile credits for prefabs in avatars and worlds.

## Installation

1. Add the package to your VRChat Creator Companion (VCC) by adding the repository URL: `https://github.com/GirlyDrink/credit-tool.git`.
2. Install `com.girlydrink.credit-tool` via the VCC.

## Usage

1. **Add Credits to Prefabs**:
   - Attach the `CreditComponent` to any prefab in your avatar or world in the Unity Editor.
   - Fill in the `Author Name`, `Asset Name` (single asset per prefab), and optionally an `Asset Link` (e.g., a store or GitHub URL).
   - Note: `CreditComponent` implements `IEditorOnly` and will be stripped from VRChat builds.

2. **Generate Credit List**:
   - Open the Credit Tool window via `Tools > Credit Tool`.
   - Drag a root GameObject (e.g., your avatar or world root) into the "Target GameObject" field.
   - Click "Generate Credit List" to display the formatted credit list in a textbox.
   - Select and copy the text from the textbox to paste into your VRChat world or avatar description.

## Output Format

The tool generates a list in the format: 
Author1 (Link): Asset1, Asset2 
Author2: Asset3

## Requirements

- Unity 2022.3
- VRChat Base SDK (^3.5.x)

## License

MIT License. See [LICENSE](LICENSE) for details.