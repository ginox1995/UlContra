using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Boss
{
    public abstract class BossState
    {
        protected BossController controller;
        protected BossStateMachine fsm;

        public BossState(BossController controller, BossStateMachine fsm)
        {
            this.controller = controller;
            this.fsm = fsm;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnLogicUpdate() { }
        public virtual void OnHandledInput() { }
        public virtual void OnPhysicsUpdate() { }

    }
}

