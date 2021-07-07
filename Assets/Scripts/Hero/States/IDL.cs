using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class IDL : HeroState
    {
        private Rigidbody2D rgb;
        private Animator animHero;
        public IDL(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody2D>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rgb.velocity = new Vector2(0, rgb.velocity.y);
            
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            if (Input.GetAxisRaw("Horizontal")!=0)
            {
                hero.Run();
            }
            if (Input.GetKeyDown(KeyCode.Space) && hero.IsGrounded())
            {
                hero.Jump();
            }
           
        }
    }
}

