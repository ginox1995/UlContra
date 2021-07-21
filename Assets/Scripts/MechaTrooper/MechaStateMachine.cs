using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Mecha
{
    public class MechaStateMachine
    {
        private MechaState currentstate;
        
        public void Start(MechaState initialState)
        {
            this.currentstate = initialState;
            this.currentstate.OnEnter();
        }
        public void ChangeState(MechaState newState)
        {
            this.currentstate.OnExit();
            this.currentstate = newState;
            this.currentstate.OnEnter();
        }
        public MechaState getMechaState()
        {
            return currentstate;
        }
    }
}

