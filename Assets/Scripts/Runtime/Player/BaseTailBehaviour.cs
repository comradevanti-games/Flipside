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

        private BaseSideAbilities _abilities;

        private Quaternion previousRotation;
        // Start is called before the first frame update
        void Start()
        {
            playerBehaviour = BasePlayerBehaviour.Instance;
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerBehaviour == null) playerBehaviour = BasePlayerBehaviour.Instance;
            if (playerBehaviour != null && playerBehaviour.CurrentSide == Side.TAIL) return;
           /** Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(hit.point);
            }*/
        }
        
        public void ToggleAbilityActive()
        {
            if (_abilities) _abilities.abilityActive = !_abilities.abilityActive;
        }

        public void SetAbilityActiveTrue()
        {
            _abilities.abilityActive = true;
            Invoke("SetAbilityActiveFalse", 1.2f);
        }

        public void SetAbilityActiveFalse()
        {
            _abilities.abilityActive = false;
            transform.rotation = previousRotation;
        }

        public void Slap(BaseSideAbilities abilities)
        {
            previousRotation = transform.rotation;
            Vector3 lookAt = MouseHelper.Instance.TryGetMousePosition();
            //if (!lookAt.Equals(Vector3.negativeInfinity)) transform.LookAt(lookAt);
            animator.SetTrigger("Attack");
            _abilities = abilities;
        }

    }
}
