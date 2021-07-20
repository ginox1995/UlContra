using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.NormalRobot
{
    public class NormalRobotState 
    {
        protected NormalRobotController normalrobot;
        protected NormalRobotStateMachine fsm;
        public NormalRobotState( NormalRobotController normalrobot, NormalRobotStateMachine fsm)
        {
            this.normalrobot = normalrobot;
            this.fsm = fsm;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnHandleInput() { }
        public virtual void OnLogicUpdate() { }
        public virtual void OnPhysicsUpdate() { }
    }
}

