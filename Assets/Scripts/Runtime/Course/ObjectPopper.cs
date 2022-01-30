using System.Collections;
using UnityEngine;

namespace Foxy.Flipside
{

    public class ObjectPopper : MonoBehaviour
    {

        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;


        public void Init(float popTime)
        {
            IEnumerator WaitAndPop()
            {
                while (Time.time < popTime) yield return null;
                Pop();
            }

            StartCoroutine(WaitAndPop());
        }

        private void Pop()
        {
            collider.enabled = false;
            rigidbody.isKinematic = false;
        }

    }

}