using UnityEngine;

namespace Foxy.Flipside
{

    [CreateAssetMenu(menuName = "Flipside/Item-material", fileName = "New item-material")]
    public class ItemMaterial : ScriptableObject
    {

        public Material material;
        public Vector2 size;

    }

}