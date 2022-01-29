using UnityEngine;

namespace Foxy.Flipside
{

    public class HeightKill : MonoBehaviour
    {

        [SerializeField] private float depthHeight;


        private float Y => transform.position.y;

        private bool ShouldDie => Y < depthHeight;


        private void Update()
        {
            if (ShouldDie) Die();
        }

        private void Die() =>
            Destroy(gameObject);

    }

}