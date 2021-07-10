using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class HeroController : MonoBehaviour
    {
        private HeroStateMachine fsm;
        private HeroState runningState;
        private HeroState jumpingState;
        private HeroState shootingState;
        private HeroState dyingState;
        private HeroState idlState;
        private BoxCollider boxCollider;
        private CapsuleCollider capsuleCollider;
        [SerializeField] private LayerMask platformLayer;
        public float runningspeed;
        public float jumpspeed;
        private float input;
 
        
        void Start()
        {
            fsm = new HeroStateMachine();
            runningState = new Running(this, fsm);
            jumpingState = new Jumping(this, fsm);
            shootingState = new Shooting(this, fsm);
            dyingState = new Dying(this, fsm);
            idlState = new IDL(this, fsm);
            boxCollider = GetComponent<BoxCollider>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            //Estado inicial
            fsm.Start(idlState);

        }
        private void FixedUpdate()
        {
            fsm.GetCurrentState().onPhysicsUpdate();
        }
        // Update is called once per frame
        void Update()
        {
            
            fsm.GetCurrentState().onHandleInput();
            fsm.GetCurrentState().onLogicUpdate();
            IsGrounded();
        }
        public void Run()
        {
            fsm.ChangeState(runningState);
        }
        public void Jump() {
            fsm.ChangeState(jumpingState);
        }
        public void IDL()
        {
            fsm.ChangeState(idlState);
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
    }
}

