using System;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class Speeds
    {
        public float speed, rollSpeed, normalSpeed, tripSpeed;
    }

    public class PlayerMov : MonoBehaviour
    {
        public Speeds speeds;
        public float rollDuration, rollCooldownDuration, tripDuration, jumpDuration;
        public float jumpForce, customGravity;
        public float rotationSpeed;
        public Transform head, model;

        public LayerMask layerJump, layerTrip, layerObstacles;

        private Rigidbody rb;
        private CapsuleCollider playerCollider;
        private float originalColliderHeight, originalColiderPosY;
        [HideInInspector] public bool isRolling, isTripping, isRollInCooldown, isJumping, isRunnig;
        private float timerRoll, timerTrip, timerJump, timerRollCooldown;

        [HideInInspector] public Rigidbody rbOfGround = null;

        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerCollider = GetComponent<CapsuleCollider>();
            originalColliderHeight = playerCollider.height;
            originalColiderPosY = playerCollider.center.y;
            isRolling = false;
            isTripping = false;
            isRollInCooldown = false;
            isJumping = false;
        }

        // Update is called once per frame
        void Update()
        {
            Jump();
            Move();
            Roll();
            Trip();
        }

        public void Move()
        {
            Vector2 inputMov = new Vector2();
            inputMov.x = Input.GetAxisRaw("Horizontal");
            inputMov.y = Input.GetAxisRaw("Vertical");

            isRunnig = false;
            if (inputMov.magnitude > 0.1f)
            {
                isRunnig = true;
            }

            //if (!isRolling)
            //{
            Orientate(inputMov);
            //}

            if (isRolling && inputMov.magnitude < 0.2f)
            {
                inputMov.x = model.transform.forward.x;
                inputMov.y = model.transform.forward.z;
            }

            inputMov = inputMov.normalized * speeds.speed;

            if (!CheckAhead(inputMov))
            {
                Vector3 nextVelocity = new Vector3(inputMov.x, rb.velocity.y, inputMov.y);
                if (rbOfGround != null)
                {
                    nextVelocity.x += rbOfGround.velocity.x;
                    nextVelocity.z += rbOfGround.velocity.z;
                }
                rb.velocity = nextVelocity;
            }
            else
            {
                isRunnig = false;
            }

        }

        private void Orientate(Vector2 direction)
        {
            if (direction.magnitude > 0.5f)
            {
                head.localPosition = new Vector3(direction.x, 0, direction.y);
                model.transform.DOLookAt(head.position, rotationSpeed);
            }
        }

        private void Jump()
        {
            if (!CheckGround())
            {
                rb.AddForce(Vector3.down * customGravity * 30 * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
            {
                if (!isRolling)
                {
                    isJumping = true;
                    timerJump = jumpDuration;
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                }
            }

            if (Input.GetKey(KeyCode.Space) && isJumping)
            {
                if (timerJump > 0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                    timerJump -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }

        public bool CheckGround()
        {
            Vector3 origin = transform.position + Vector3.up * 0.15f;
            return Physics.Raycast(origin, Vector3.down, 0.5f, layerJump);
        }

        private bool CheckTrip()
        {
            Vector3 origin = transform.position + Vector3.up * 0.15f;
            return Physics.Raycast(origin, Vector3.down, 0.5f, layerTrip);
        }

        private void Roll()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && CheckGround() && !isRollInCooldown && !isTripping)
            {
                isRollInCooldown = true;
                isRolling = true;
                speeds.speed = speeds.rollSpeed;
                timerRoll = rollDuration;
                timerRollCooldown = rollCooldownDuration;
                playerCollider.height /= 3;
                playerCollider.center = Vector3.up * 0.3f;
            }

            if (isRolling)
            {
                timerRoll -= Time.deltaTime;
                if (timerRoll < 0)
                {
                    speeds.speed = speeds.normalSpeed;
                    isRolling = false;
                }
            }

            if (isRollInCooldown)
            {
                timerRollCooldown -= Time.deltaTime;
                if (timerRollCooldown < 0)
                {
                    isRollInCooldown = false;
                    playerCollider.height = originalColliderHeight;
                    playerCollider.center = Vector3.up * originalColiderPosY;
                }
            }
        }

        private void Trip()
        {
            if (CheckTrip())
            {
                isTripping = true;
                speeds.speed = speeds.tripSpeed;
                timerTrip = tripDuration;
            }

            if (isTripping)
            {
                timerTrip -= Time.deltaTime;
                if (timerTrip < 0)
                {
                    speeds.speed = speeds.normalSpeed;
                    timerTrip = tripDuration;
                    isTripping = false;
                }
            }
        }

        private bool CheckAhead(Vector2 direction2)
        {
            Vector3 direction = new Vector3(direction2.x, 0, direction2.y);
            Vector3 origin1 = transform.position + Vector3.up * 0.15f;
            Vector3 origin2 = transform.position + Vector3.up * 1f;

            if (Physics.Raycast(origin1, direction, 0.7f, layerObstacles))
            {
                return true;
            }

            if (Physics.Raycast(origin2, direction, 0.7f, layerObstacles))
            {
                return true;
            }

            return false;
        }

    }
}
