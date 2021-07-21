using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.FirePoint;

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
            this.animationAttribute = "IDL";

        }

        public override void OnEnter()
        {
            base.OnEnter();
            rgb.velocity = new Vector3(0, rgb.velocity.y,0);
            animHero.SetBool(animationAttribute, false);           
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            //Debug.Log(Input.GetAxis("Vertical"));
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                hero.Run();
                /*if (Input.GetAxis("Vertical") > 0)
                {
                    hero.RunLookingUp();
                }
                else
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        hero.RunLookingDown();
                    }
                    else
                    {
                        hero.Run();
                    }
                }*/
            }

            if (Input.GetKeyDown(KeyCode.Space))
                hero.Jump();

            if (Input.GetAxisRaw("Vertical") > 0)
                hero.LookUp();

            if (Input.GetAxisRaw("Vertical") < 0)
                hero.LookDown();
           
        }
    }
}

