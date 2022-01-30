using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        [SerializeField] private SpriteRenderer tailUpRenderer, tailDownRenderer;

        [SerializeField] private string dieScene;
        
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
                Jump(MousePoint.instance.OnPlane);
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
                SceneManager.LoadScene(dieScene);
            }
        }

        void Flip()
        {
            if (flipping) return;
            faceSideAbilities.CancelAllAbilites();
            tailSideAbilities.CancelAllAbilites();
            
            if (grounded)
            {
                Vector3? targetPos = MousePoint.instance.OnPlane;
                if (targetPos != null) 
                    Jump(targetPos);
                transform.position += new Vector3(0.0f, 0.5f, 0.0f);
            }
            StartCoroutine(FlipAnimation());
            side = side.Side == Side.HEAD ? tails : heads;
            tailCollider.enabled = side.Side != Side.HEAD;
            tailDownRenderer.enabled = side.Side == Side.TAIL;
            tailUpRenderer.enabled = side.Side != Side.TAIL;
        }

        void Jump(Vector3? targetPoint)
        {
            if (targetPoint == null) return;
            Vector3 direction = (targetPoint - transform.position).Value.normalized;
            playerRB.AddForce(new Vector3(direction.x * side.Velocity, side.JumpForce,
                    direction.z * side.Velocity),
                ForceMode.Force);
            grounded = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Floor"))
                grounded = true;
            if (other.collider.CompareTag("Enemy"))
                playerRB.AddForce((other.transform.position - transform.position) * other.impulse.magnitude);
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.collider.CompareTag("Floor"))
                grounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.CompareTag("Floor"))
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
