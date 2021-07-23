using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Boss
{
    public class BossStateMachine
    {
        private BossState currentState;

        public void Start(BossState initialState)
        {
            this.currentState = initialState;
            this.currentState.OnEnter();
        }

        public void ChangeState(BossState newState)
        {
            this.currentState.OnExit();
            this.currentState = newState;
            this.currentState.OnEnter();
        }
        public BossState GetCurrentState()
        {
            return currentState;
        }
    }
}

