using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FSM: FINITE STATE MACHINE
namespace ProyectoFinal.Hero
{
    public abstract class HeroState
    {
        protected HeroController hero;
        protected HeroStateMachine herosfm;
        public string animationAttribute;
        
       public HeroState(HeroController hero, HeroStateMachine herosfm)
        {
            this.hero = hero;
            this.herosfm = herosfm;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void onHandleInput() { }
        public virtual void onLogicUpdate() { }
        public virtual void onPhysicsUpdate() { }
    }
}

