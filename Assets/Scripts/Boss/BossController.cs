using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Boss
{
    public class BossController : MonoBehaviour
    {
        //State machine and states
        private BossStateMachine fsm;
        private BossState walkingState;
        private BossState jumpingState;
        private BossState attackingState;
        //Others
        public float bossSpeed;
        public float bossJumpSpeed;
        public float bossHP;
        [SerializeField] public Transform limitWalk;
        [SerializeField] public Transform startPosition;
        // Start is called before the first frame update
        void Start()
        {
            fsm = new BossStateMachine();
            walkingState = new Walking(this, fsm);
            jumpingState = new Jumping(this, fsm);
            attackingState = new Attacking(this, fsm);

            fsm.Start(walkingState);
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            fsm.GetCurrentState().OnPhysicsUpdate();
        }
        void Update()
        {
            fsm.GetCurrentState().OnLogicUpdate();
            fsm.GetCurrentState().OnHandledInput();
        }
        public void Walk()
        {
            fsm.ChangeState(walkingState);
        }
        public void Jump()
        {
            fsm.ChangeState(jumpingState);
        }
        public void Attack()
        {
            fsm.ChangeState(attackingState);
        }
    }
}

