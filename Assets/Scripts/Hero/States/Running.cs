using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.FirePoint;

namespace ProyectoFinal.Hero
{
    public class Running : HeroState
    {
        private float speed;
        private Rigidbody rgb;
        private float inputH;
        private float inputV;

        private SpriteRenderer sprite;
        private Animator animHero;
        //public string animationAttribute = "Running";
        public Running(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody>();
            speed= hero.runningspeed;
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
            this.animationAttribute = "Running";
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
                hero.IDL();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                hero.Jump();
            }
            
            /*if (inputV > 0)
                hero.RunLookingUp();
            
            if (inputV > 0)
                hero.RunLookingDown();*/

            if (Input.GetKeyDown(KeyCode.LeftControl))
                hero.RunShooting();

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

        public override void onPhysicsUpdate()
        {
            rgb.velocity = new Vector3(speed*inputH, rgb.velocity.y,0);

        }
    }
}

