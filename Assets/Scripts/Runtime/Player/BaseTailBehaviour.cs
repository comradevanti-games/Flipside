using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxy.Flipside
{
    public class BaseTailBehaviour : MonoBehaviour
    {

        private Animator animator;

        private BasePlayerBehaviour playerBehaviour;
        // Start is called before the first frame update
        void Start()
        {
            playerBehaviour = BasePlayerBehaviour.Instance;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(lookAt);
            }
        }

        public void Slap()
        {
            animator.SetTrigger("Attack");
        }
    }
}
