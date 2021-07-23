using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class Dying : HeroState
    {
        public Dying(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            this.animationAttribute = "Die";    
        }
    }
}

