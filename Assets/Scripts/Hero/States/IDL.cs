using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class IDL : HeroState
    {
        private Rigidbody rgb;
        private Animator animHero;
        public IDL(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody>();
            animHero = hero.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rgb.velocity = new Vector3(0, rgb.velocity.y,0);
            animHero.SetBool("Jumping", false);
            
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            if (Input.GetAxisRaw("Horizontal")!=0)
            {
                hero.Run();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hero.Jump();
            }
           
        }
    }
}

