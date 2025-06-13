using UnityEngine;
using VRC.SDKBase;

namespace GirlyDrink.CreditTool
{
    public class CreditComponent : MonoBehaviour, IEditorOnly
    {
        public string authorName = "";
        public string authorStoreLink = "";
        public string assetName = "";
        public string assetLink = "";
    }
}