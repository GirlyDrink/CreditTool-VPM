#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GirlyDrink.CreditTool;

namespace GirlyDrink.CreditTool.Editor
{
    public class CreditToolWindow : EditorWindow
    {
        private GameObject targetObject;
        private Vector2 scrollPosition;
        private string creditList = "";
        private Vector2 textScrollPosition;
        private bool includeAssetLinks = true;
        private bool includeAuthorLinks = true;

        [MenuItem("Tools/GirlyDrink's Tools/Credit Tool")]
        public static void ShowWindow()
        {
            var window = GetWindow<CreditToolWindow>("Credit Tool");
            window.minSize = new Vector2(300, 400);
        }

        private void OnGUI()
        {
            GUILayout.Label("Credit Tool by GirlyDrink", EditorStyles.boldLabel);
            GUILayout.Space(10);

            targetObject = (GameObject)EditorGUILayout.ObjectField(
                "Target GameObject",
                targetObject,
                typeof(GameObject),
                true
            );

            GUILayout.Space(10);
            GUILayout.Label("Output Options:", EditorStyles.boldLabel);
            includeAssetLinks = EditorGUILayout.Toggle("Include Asset Links", includeAssetLinks);
            includeAuthorLinks = EditorGUILayout.Toggle("Include Author Store Links", includeAuthorLinks);

            GUILayout.Space(10);
            if (GUILayout.Button("Generate Credit List"))
            {
                if (targetObject == null)
                {
                    EditorUtility.DisplayDialog("Error", "Please select a GameObject.", "OK");
                    return;
                }

                creditList = GenerateCreditList(targetObject);
            }

            GUILayout.Space(10);
            GUILayout.Label("Credit List:", EditorStyles.boldLabel);
            textScrollPosition = GUILayout.BeginScrollView(textScrollPosition, GUILayout.Height(150));
            GUIStyle textAreaStyle = new GUIStyle(EditorStyles.textArea)
            {
                wordWrap = true
            };
            creditList = GUILayout.TextArea(creditList, textAreaStyle, GUILayout.ExpandHeight(true));
            GUILayout.EndScrollView();

            GUILayout.Space(10);
            GUILayout.Label("Instructions:", EditorStyles.boldLabel);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            GUILayout.Label(
                "- Add the 'Credit Component' to prefabs with author and asset details in the Editor.\n" +
                "- Fill in Author Name, Author Store Link, Asset Name, and Asset Link as needed.\n" +
                "- Select a root GameObject (e.g., avatar or world root).\n" +
                "- Choose whether to include Asset Links and Author Store Links in the output.\n" +
                "- Click 'Generate Credit List' to display credits in the textbox below.\n" +
                "- Select and copy the text from the textbox to paste into your VRChat description.\n" +
                "- The Credit Component is Editor-only and will not be included in VRChat builds.",
                EditorStyles.wordWrappedLabel
            );
            GUILayout.EndScrollView();
        }

        private string GenerateCreditList(GameObject root)
        {
            // Collect all CreditComponents in the hierarchy
            var creditComponents = root.GetComponentsInChildren<CreditComponent>(true);

            // Group by author
            var creditsByAuthor = new Dictionary<string, List<(string assetName, string assetLink)>>();
            foreach (var component in creditComponents)
            {
                if (string.IsNullOrEmpty(component.authorName) || string.IsNullOrEmpty(component.assetName))
                    continue;

                string authorKey = component.authorName;
                if (includeAuthorLinks && !string.IsNullOrEmpty(component.authorStoreLink))
                    authorKey += $" ({component.authorStoreLink})";

                if (!creditsByAuthor.ContainsKey(authorKey))
                    creditsByAuthor[authorKey] = new List<(string, string)>();

                creditsByAuthor[authorKey].Add((
                    component.assetName,
                    includeAssetLinks && !string.IsNullOrEmpty(component.assetLink) ? component.assetLink : ""
                ));
            }

            // Format the output
            StringBuilder output = new StringBuilder();
            foreach (var kvp in creditsByAuthor.OrderBy(k => k.Key))
            {
                var assets = kvp.Value
                    .Distinct(new AssetNameEqualityComparer())
                    .Select(x => string.IsNullOrEmpty(x.assetLink) ? x.assetName : $"{x.assetName} ({x.assetLink})")
                    .ToList();
                string assetList = string.Join(", ", assets);
                output.AppendLine($"{kvp.Key}: {assetList}");
            }

            return output.Length > 0 ? output.ToString().Trim() : "No credits found.";
        }

        // Custom equality comparer to deduplicate based on assetName
        private class AssetNameEqualityComparer : IEqualityComparer<(string assetName, string assetLink)>
        {
            public bool Equals((string assetName, string assetLink) x, (string assetName, string assetLink) y)
            {
                return x.assetName == y.assetName;
            }

            public int GetHashCode((string assetName, string assetLink) obj)
            {
                return obj.assetName.GetHashCode();
            }
        }
    }
}
#endif