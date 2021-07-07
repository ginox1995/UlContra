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
        private BoxCollider2D boxCollider;
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
            boxCollider = GetComponent<BoxCollider2D>();
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
            float extension = 0.1f;
            Color color;
            RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y+extension,platformLayer);
            if (raycastHit.collider!=null)
            {
                color = Color.green;
                Debug.Log("Esta en el suelo");
            }
            else
            {
                color = Color.red;
                Debug.Log("Esta en el aire");
            }
            Debug.DrawRay(boxCollider.bounds.center,Vector2.down*(boxCollider.bounds.extents.y+extension),color);

            return raycastHit.collider!= null;
        }
    }
}

