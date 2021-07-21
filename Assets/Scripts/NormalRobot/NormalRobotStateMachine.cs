using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.NormalRobot
{
    public class NormalRobotStateMachine
    {
        private NormalRobotState currentState;

        public void Start(NormalRobotState initialState)
        {
            this.currentState = initialState;
            this.currentState.OnEnter();
        }

        public void ChangeState(NormalRobotState newState)
        {
            this.currentState.OnExit();
            this.currentState = newState;
            this.currentState.OnEnter();
        }

        public NormalRobotState getCurrentState()
        {
            return currentState;
        }
    }
}

