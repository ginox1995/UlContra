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
        private HeroState runningShootingState;
        private HeroState runningLookingUpState;
        private HeroState runningLookingDownState;
        private HeroState lookingUpState;
        private HeroState lookingDownState;
        private BoxCollider2D boxCollider;
        private FireController fireController;
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
            runningShootingState = new RunningShooting(this, fsm);
            runningLookingUpState = new RunningLookingUp(this, fsm);
            runningLookingDownState = new RunningLookingDown(this, fsm);
            lookingUpState = new LookingUp(this, fsm);
            lookingDownState = new LookingDown(this, fsm);

            boxCollider = GetComponent<BoxCollider2D>();

            fireController = GameObject.Find("FirePoint").GetComponent<FireController>();

            
            //Estado inicia
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

            if (Input.GetButton("Fire1"))
                fireController.Fire();
            
            
        }
        public void Run()
        {
            fsm.ChangeState(runningState);
            animationAttribute = ((Running)runningState).animationAttribute;
        }
        public void Jump() {
            fsm.ChangeState(jumpingState);
            animationAttribute = ((Jumping)jumpingState).animationAttribute;
        }
        public void IDL()
        {
            fsm.ChangeState(idlState);
            animationAttribute = ((IDL)idlState).animationAttribute;
        }
        public void RunShooting()
        {
            fsm.ChangeState(runningShootingState);
            animationAttribute = ((RunningShooting)runningShootingState).animationAttribute;
        }
        public void RunLookingUp()
        {
            fsm.ChangeState(runningLookingUpState);
            animationAttribute = ((RunningLookingUp)runningLookingUpState).animationAttribute;
        }
        public void RunLookingDown()
        {
            fsm.ChangeState(runningLookingDownState);
            animationAttribute = ((RunningLookingDown)runningLookingDownState).animationAttribute;
        }
        public void LookUp()
        {
            fsm.ChangeState(lookingUpState);
            animationAttribute = ((LookingUp)lookingUpState).animationAttribute;
        }
        public void LookDown()
        {
            fsm.ChangeState(lookingDownState);
            animationAttribute = ((LookingDown)lookingDownState).animationAttribute;
        }

        public string GetStateAnimatinoAttribute()
        {
            //string animationAttribute = fsm.GetCurrentState();

            //return animationAttribute;
            return "";
        }

        public bool IsGrounded()
        {
            float extension = 0.1f;
            Color color;
            RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y+extension,platformLayer);
            if (raycastHit.collider!=null)
            {
                color = Color.green;
                //Debug.Log("Esta en el suelo");
            }
            else
            {
                color = Color.red;
                //Debug.Log("Esta en el aire");
            }
            Debug.DrawRay(boxCollider.bounds.center,Vector2.down*(boxCollider.bounds.extents.y+extension),color);

            return raycastHit.collider!= null;
        }
        public HeroState GetCurrentheroState() { return fsm.GetCurrentState(); }
    }
}

