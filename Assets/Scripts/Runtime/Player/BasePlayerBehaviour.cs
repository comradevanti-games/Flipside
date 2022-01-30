using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Foxy.Flipside
{
    public class BasePlayerBehaviour : MonoBehaviour
    {
        public static BasePlayerBehaviour Instance;

        [SerializeField] private CoinSide heads, tails;
        [SerializeField] private float flipDuration = 0.5f;
        [SerializeField] private Quaternion downSideTransform;
        [SerializeField] private Collider tailCollider;
        
        private Quaternion upSideTransform;

        private BaseSideAbilities faceSideAbilities, tailSideAbilities;

        private CoinSide side;

        public Side CurrentSide => side.Side;

        private Rigidbody playerRB;
        private Camera camera;
        public bool grounded = true;
        private bool flipped = false, flipping = false;

        // Start is called before the first frame update
        void Start()
        {
            upSideTransform = this.transform.rotation;
            Instance = this;
            if (side == null) side = tails;
            playerRB = GetComponent<Rigidbody>();
            camera = Camera.main;

            faceSideAbilities = GetComponent<FaceSideAbilities>();
            tailSideAbilities = GetComponent<TailSideAbilities>();
        }

        // Update is called once per frame
        void Update()
        {
            /**Vector3 mousePos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //transform.LookAt(lookAt);
            */
            if (Input.GetMouseButtonUp(0) && grounded)
            {
                Jump(MouseHelper.Instance.TryGetMousePosition());
            }
            //}

            if (Input.GetMouseButtonUp(1))
            {
                Flip();
            }

            foreach (KeyCode keyCode in faceSideAbilities.PossibleKeyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    if (!faceSideAbilities.abilityActive)
                        faceSideAbilities.FireAbility(side.Side == Side.TAIL, keyCode);
                }
            }

            foreach (KeyCode possibleKeyCode in tailSideAbilities.PossibleKeyCodes)
            {
                if (Input.GetKey(possibleKeyCode))
                {
                    if (!tailSideAbilities.abilityActive)
                        tailSideAbilities.FireAbility(side.Side == Side.HEAD, possibleKeyCode);
                }
            }

            if (transform.position.y < -10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        void Flip()
        {
            if (flipping) return;
            faceSideAbilities.CancelAllAbilites();
            tailSideAbilities.CancelAllAbilites();
            
            if (grounded)
            {
                Vector3 targetPos = MouseHelper.Instance.TryGetMousePosition();
                if (targetPos.Equals(Vector3.negativeInfinity)) playerRB.AddForce(transform.up * 10);
                else Jump(targetPos);
            }
            StartCoroutine(FlipAnimation());
            side = side.Side == Side.HEAD ? tails : heads;
            tailCollider.enabled = side.Side != Side.HEAD;
        }

        void Jump(Vector3 targetPoint)
        {
            if (targetPoint.Equals(Vector3.negativeInfinity)) return;
            Vector3 direction = (targetPoint - transform.position).normalized;
            playerRB.AddForce(new Vector3(direction.x * side.Velocity, side.JumpForce,
                    direction.z * side.Velocity),
                ForceMode.Force);
        }

        private void OnCollisionEnter(Collision other)
        {
            grounded = true;
        }

        private void OnCollisionStay(Collision other)
        {
            grounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            grounded = false;
        }

        IEnumerator FlipAnimation()
        {
            flipping = true;
            float step = 0f;

            Quaternion target = downSideTransform;
            if (flipped)
            {
                target = upSideTransform;
            }
            
            while (step < flipDuration)
            {
                step += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, target, step / flipDuration);
                yield return null;
            }

            flipped = !flipped;
            flipping = false;
            yield return null;
        }

        public Rigidbody PlayerRb => playerRB;
    }
}
