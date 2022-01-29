using System.Collections;
using UnityEngine;

namespace Foxy.Flipside
{

    public class ObjectPopper : MonoBehaviour
    {

        [SerializeField] private float timeUntilPop;
        [SerializeField] private float timeUntilFirstPop;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;


        public void Init(int tileIndex) =>
            StartCoroutine(WaitAndPop(tileIndex * timeUntilPop + timeUntilFirstPop));

        private IEnumerator WaitAndPop(float popTime)
        {
            while (Time.time < popTime) yield return null;
            Pop();
        }

        private void Pop()
        {
            collider.enabled = false;
            rigidbody.isKinematic = false;
        }

    }

}