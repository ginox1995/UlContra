using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.NormalRobot
{
    
    public class NormalRobotController : MonoBehaviour
    {
        private NormalRobotStateMachine fsm;
        public float robotSpeed;
        public float robotHP;
        //[SerializeField] public GameObject robot;
        //Estados
        private WalkingState walkingRobot;
        private DyingState dyingRobot;
        
        void Start()
        {
            
            fsm = new NormalRobotStateMachine();
            walkingRobot = new WalkingState(this, fsm);
            dyingRobot = new DyingState(this, fsm);
            //Seteo estado inicial
            fsm.Start(walkingRobot);
        }

        void Update()
        {
            fsm.getCurrentState().OnHandleInput();
            fsm.getCurrentState().OnLogicUpdate();
        }
        private void FixedUpdate()
        {
            fsm.getCurrentState().OnPhysicsUpdate();
        }

        public void Damaged(float damage)
        {
            if (this.robotHP <= damage)
                this.robotHP = 0;
            else
                this.robotHP = this.robotHP - damage;
        }

        public void dying()
        {
            fsm.ChangeState(dyingRobot);
        }
    }
}

