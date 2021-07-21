using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.FirePoint;

namespace ProyectoFinal.Hero
{
    public class RunningShooting : HeroState
    {
        private float speed;
        private float inputH;
        private float inputV;
        private Rigidbody2D rgb;
        private SpriteRenderer sprite;
        private Animator animHero;
        //public string animationAttribute = "Shooting";

        public RunningShooting(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody2D>();
            speed= hero.runningspeed;
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
            this.animationAttribute = "Shooting";
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
            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");
            if (inputH==0)
            {
                hero.IDL();
            }
            if (inputV > 0)
            {
                //animHero.SetBool("Running", true);
            }
            if (inputV > 0)
            {
                //animHero.SetBool("Running", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
                hero.Run();
            
        }

        public override void onLogicUpdate()
        {
            if (inputH < 0)
            {
                sprite.flipX = true;
                GameObject.Find("FirePoint").GetComponent<FireController>().FixTransforme(animationAttribute);
            }
            if (inputH > 0)
            {
                sprite.flipX = false;
                GameObject.Find("FirePoint").GetComponent<FireController>().FixTransforme(animationAttribute);
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