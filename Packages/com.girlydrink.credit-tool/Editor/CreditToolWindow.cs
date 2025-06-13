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

        [MenuItem("Tools/Credit Tool")]
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
                "- Select a root GameObject (e.g., avatar or world root).\n" +
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
            var creditsByAuthor = new Dictionary<string, List<string>>();
            foreach (var component in creditComponents)
            {
                if (string.IsNullOrEmpty(component.authorName) || string.IsNullOrEmpty(component.assetName))
                    continue;

                string authorKey = component.authorName;
                if (!string.IsNullOrEmpty(component.assetLink))
                    authorKey += $" ({component.assetLink})";

                if (!creditsByAuthor.ContainsKey(authorKey))
                    creditsByAuthor[authorKey] = new List<string>();

                creditsByAuthor[authorKey].Add(component.assetName);
            }

            // Format the output
            StringBuilder output = new StringBuilder();
            foreach (var kvp in creditsByAuthor.OrderBy(k => k.Key))
            {
                string assets = string.Join(", ", kvp.Value.Distinct());
                output.AppendLine($"{kvp.Key}: {assets}");
            }

            return output.Length > 0 ? output.ToString().Trim() : "No credits found.";
        }
    }
}
#endif