using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Mecha
{
    public class MechaState
    {
        protected MechaController mecha;
        protected MechaStateMachine fsm;

        public MechaState(MechaController mecha, MechaStateMachine fsm)
        {
            this.mecha = mecha;
            this.fsm = fsm;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnHandledInput() { }
        public virtual void OnLogicUpdate() { }
        public virtual void OnPhysicsUpdate() { }

    }
}

