using UnityEngine;
using VRC.SDKBase;

namespace Tchoutchawn.CreditTool
{
    public class CreditComponent : MonoBehaviour, IEditorOnly
    {
        public string authorName = "";
        public string assetName = "";
        public string assetLink = "";
    }
}