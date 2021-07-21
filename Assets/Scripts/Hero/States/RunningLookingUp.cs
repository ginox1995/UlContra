using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class RunningLookingUp : HeroState
    {
        private float speed;
        private float inputH;
        private float inputV;
        private Rigidbody2D rgb;
        private SpriteRenderer sprite;
        private Animator animHero;
        //public string animationAttribute = "RunningUp";
        public RunningLookingUp(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody2D>();
            speed= hero.runningspeed;
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
            this.animationAttribute = "RunningUp";
        }

        public override void OnEnter()
        {
            animHero.SetBool(animationAttribute, true);
        }

        public override void OnExit()
        {
            animHero.SetBool(animationAttribute, false);
            
        }

        public override void onHandleInput()
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                hero.IDL();
            }
            else
            {

                if (Input.GetAxis("Vertical") < 0)
                {
                    hero.RunLookingDown();
                }
                else
                {
                    if (Input.GetAxis("Vertical") == 0)
                        hero.Run();

                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && hero.IsGrounded())
                hero.Jump();
        }

        public override void onLogicUpdate()
        {
            if (inputH < 0)
            {
                sprite.flipX = true;
            }
            if (inputH > 0)
            {
                sprite.flipX = false;
            }
           
        }

        public void changeAnimation() 
        {

        }


        public override void onPhysicsUpdate()
        {
            rgb.velocity = new Vector2(speed * inputH, rgb.velocity.y);
        }
    }
}