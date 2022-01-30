using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foxy.Flipside
{
    public class BaseSideAbilities : MonoBehaviour
    {

        protected Dictionary<KeyCode, SideDownAbility> sideDownAbilities = new Dictionary<KeyCode, SideDownAbility>();
        protected Dictionary<KeyCode, SideUpAbility> sideUpAbilities = new Dictionary<KeyCode, SideUpAbility>();

        public List<KeyCode> PossibleKeyCodes
        {
            get
            {
                List<KeyCode> keyCodes = sideDownAbilities.Keys.ToList();
                keyCodes.AddRange(sideUpAbilities.Keys.ToList());

                return keyCodes;
            }
        }

        protected BasePlayerBehaviour playerBehaviour;

        public bool abilityActive;

        protected delegate void SideDownAbility();

        protected delegate void SideUpAbility();

        private void Start()
        {
        }

        protected void Init()
        {
            playerBehaviour = GetComponent<BasePlayerBehaviour>();
        }

        public void FireAbility(bool sideUp, KeyCode buttonPressed)
        {
            if (sideUp && sideUpAbilities.ContainsKey(buttonPressed))
            {
                sideUpAbilities[buttonPressed]();
            }
            else if (!sideUp && sideDownAbilities.ContainsKey(buttonPressed))
            {
                sideDownAbilities[buttonPressed]();
            }
        }

        public virtual void CancelAllAbilites()
        {
            
        }
    }
}
