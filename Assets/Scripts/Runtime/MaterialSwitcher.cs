using UnityEngine;

namespace Foxy.Flipside
{

    public class MaterialSwitcher : MonoBehaviour
    {

        [SerializeField] private ItemMaterial[] materialItems;
        [SerializeField] private new MeshRenderer renderer;


        private ItemMaterial MaterialItem
        {
            set
            {
                renderer.material = value.material;
                transform.localScale = new Vector3(value.size.x, value.size.y, 1);
            }
        }


        private void Awake() =>
            SwitchMaterial();

        public void SwitchMaterial() =>
            MaterialItem = ChooseRandomMaterial();

        private ItemMaterial ChooseRandomMaterial() =>
            materialItems[Random.Range(0, materialItems.Length)];

    }

}