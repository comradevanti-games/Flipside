using UnityEngine;

namespace Foxy.Flipside
{

    public class ZSwitcher : MonoBehaviour
    {

        [SerializeField] private Transform playerTransform;
        [SerializeField] private float minZ;
        [SerializeField] private float maxZ;


        private float PlayerZ => playerTransform.position.z;

        private Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }

        private float Z
        {
            set => Pos = new Vector3(Pos.x, Pos.y, value);
        }


        private void Awake() =>
            SwitchZ();

        public void SwitchZ() =>
            Z = PlayerZ + Random.Range(minZ, maxZ);

    }

}