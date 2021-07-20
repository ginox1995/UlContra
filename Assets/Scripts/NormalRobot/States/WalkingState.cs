using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.NormalRobot
{
    public class WalkingState : NormalRobotState
    {
        private Rigidbody rgb;
        
        public WalkingState(NormalRobotController normalrobot, NormalRobotStateMachine fsm) : base(normalrobot, fsm)
        {
            rgb = normalrobot.GetComponent<Rigidbody>();
            
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
            if (normalrobot.robotHP<=0)
            {
                normalrobot.dying();
            }
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
            rgb.velocity = new Vector3(-normalrobot.robotSpeed,rgb.velocity.y,0);

        }
    }
}

