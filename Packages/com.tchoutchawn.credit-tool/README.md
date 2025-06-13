# Credit Tool for VRChat

A Unity tool for VRChat creators to manage and compile credits for prefabs in avatars and worlds.

## Installation

1. Add the package to your VRChat Creator Companion (VCC) by adding the repository URL: `https://github.com/tchoutchawn/credit-tool.git`.
2. Install `com.tchoutchawn.credit-tool` via the VCC.

## Usage

1. **Add Credits to Prefabs**:
   - Attach the `CreditComponent` to any prefab in your avatar or world.
   - Fill in the `Author Name`, `Asset Name` (single asset per prefab), and optionally an `Asset Link` (e.g., a store or GitHub URL).

2. **Generate Credit List**:
   - Open the Credit Tool window via `Tools > Credit Tool`.
   - Drag a root GameObject (e.g., your avatar or world root) into the "Target GameObject" field.
   - Click "Generate Credit List" to compile all credits, merging assets by author, and copy them to your clipboard.
   - Paste the formatted list into your VRChat world or avatar description.

## Output Format

The tool generates a list in the format: