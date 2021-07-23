using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.Bullets;
using ProyectoFinal.FirePoint;

namespace ProyectoFinal.Hero
{
    public class HeroController : MonoBehaviour
    {
        private HeroStateMachine fsm;
        private HeroState runningState;
        private HeroState jumpingState;
        private HeroState dyingState;
        private HeroState idlState;

        private BoxCollider boxCollider;
        private CapsuleCollider capsuleCollider;

        private HeroState runningShootingState;
        private HeroState runningLookingUpState;
        private HeroState runningLookingDownState;
        private HeroState lookingUpState;
        private HeroState lookingDownState;

        private FireController fireController;
        
        [Range(0f, 10f)]
        public float heroHP;
        [SerializeField] private LayerMask platformLayer;
        public float runningspeed;
        public float jumpspeed;
        private float input;
        private string animationAttribute;
        
        void Start()
        {
            fsm = new HeroStateMachine();
            runningState = new Running(this, fsm);
            jumpingState = new Jumping(this, fsm);
            dyingState = new Dying(this, fsm);
            idlState = new IDL(this, fsm);

            boxCollider = GetComponent<BoxCollider>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            //Estado inicial
            runningShootingState = new RunningShooting(this, fsm);
            runningLookingUpState = new RunningLookingUp(this, fsm);
            runningLookingDownState = new RunningLookingDown(this, fsm);
            lookingUpState = new LookingUp(this, fsm);
            lookingDownState = new LookingDown(this, fsm);

            fireController = GameObject.Find("FirePoint").GetComponent<FireController>();

            fsm.Start(idlState);

        }
        private void FixedUpdate()
        {
            fsm.GetCurrentState().onPhysicsUpdate();
        }
        // Update is called once per frame
        void Update()
        {
            if (heroHP <= 0 || transform.position.y < 0.0f)
                Die();

            fsm.GetCurrentState().onHandleInput();
            fsm.GetCurrentState().onLogicUpdate();
            IsGrounded();

            if (Input.GetButton("Fire1"))
                fireController.Fire();
            
            
        }
        public void Run()
        {
            fsm.ChangeState(runningState);
            //animationAttribute = ((Running)runningState).animationAttribute;
        }
        public void Jump() {
            fsm.ChangeState(jumpingState);
            //animationAttribute = ((Jumping)jumpingState).animationAttribute;
        }
        public void IDL()
        {
            fsm.ChangeState(idlState);
            //animationAttribute = ((IDL)idlState).animationAttribute;
        }
        public void RunShooting()
        {
            fsm.ChangeState(runningShootingState);
            //animationAttribute = ((RunningShooting)runningShootingState).animationAttribute;
        }
        public void RunLookingUp()
        {
            fsm.ChangeState(runningLookingUpState);
            //animationAttribute = ((RunningLookingUp)runningLookingUpState).animationAttribute;
        }
        public void RunLookingDown()
        {
            fsm.ChangeState(runningLookingDownState);
            //animationAttribute = ((RunningLookingDown)runningLookingDownState).animationAttribute;
        }
        public void LookUp()
        {
            fsm.ChangeState(lookingUpState);
            //animationAttribute = ((LookingUp)lookingUpState).animationAttribute;
        }
        public void LookDown()
        {
            fsm.ChangeState(lookingDownState);
            //animationAttribute = ((LookingDown)lookingDownState).animationAttribute;
        }
        public void Die()
        {
            fsm.ChangeState(dyingState);
            //animationAttribute = ((LookingDown)lookingDownState).animationAttribute;
        }


        public bool IsGrounded()
        {
            float extension;
            bool hit;
            
            Color color;
            if (boxCollider.enabled)
            {

                extension = 0.1f;
                //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extension, platformLayer);
                hit = Physics.Raycast(boxCollider.bounds.center, Vector3.down, boxCollider.bounds.extents.y + extension, platformLayer);
                if (hit)
                {
                    color = Color.green;
                    
                }
                else
                {
                    color = Color.red;
                    

                }
                Debug.DrawRay(boxCollider.bounds.center, Vector3.down * (boxCollider.bounds.extents.y + extension), color);
                return hit;

                
            }
            else
            {
                extension = 7f;
                hit = Physics.Raycast(capsuleCollider.bounds.center, Vector3.down, capsuleCollider.bounds.extents.y + extension, platformLayer);
                if (hit)
                {
                    color = Color.green;

                }
                else
                {
                    color = Color.red;

                }
                Debug.DrawRay(capsuleCollider.bounds.center, Vector2.down * (capsuleCollider.bounds.extents.y + extension), color);

                return hit;
            }
            
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Ground"))
            {
                heroHP = heroHP - 2f;
                GameObject.Find("CurrentHeal").GetComponent<HealController>().HealModification(heroHP, 2f);
            }
        }

        public HeroState GetCurrentheroState() { return fsm.GetCurrentState(); }
    }
}

