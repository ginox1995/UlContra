using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class HeroStateMachine
    {
        private HeroState currentState;

        public void Start(HeroState initialState)
        {
            this.currentState = initialState;
            this.currentState.OnEnter();
        }

        public void ChangeState(HeroState newState)
        {
            this.currentState.OnExit();
            this.currentState = newState;
            this.currentState.OnEnter();
        }

        public HeroState GetCurrentState()
        {
            return currentState;
        }
    }
}

