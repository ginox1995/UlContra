using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.FirePoint;

namespace ProyectoFinal.Hero
{
    public class LookingUp : HeroState
    {
        private Rigidbody2D rgb;
        private Animator animHero;
        //public string animationAttribute = "LookingUp";
        public LookingUp(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody2D>();
            animHero = hero.GetComponent<Animator>();
            this.animationAttribute = "LookingUp";
        }

        public override void OnEnter()
        {
            animHero.SetBool(animationAttribute, true);
            //GameObject.Find("FirePoint").GetComponent<FireController>().FixTransforme(animationAttribute);

        }

        public override void OnExit()
        {
            animHero.SetBool(animationAttribute, false);
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            if (Input.GetAxisRaw("Vertical") == 0)
                hero.IDL();

            if (Input.GetAxisRaw("Horizontal")!=0)            
                hero.Run();
            

            if (Input.GetKeyDown(KeyCode.Space) && hero.IsGrounded())            
                hero.Jump();
            

        }
    }
}
