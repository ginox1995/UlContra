using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class Running : HeroState
    {
        private float speed;
        private float input;
        private Rigidbody2D rgb;
        private SpriteRenderer sprite;
        private Animator animHero;
        public Running(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            rgb = hero.GetComponent<Rigidbody2D>();
            speed= hero.runningspeed;
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            animHero.SetBool("Running", true);
        }

        public override void OnExit()
        {
            animHero.SetBool("Running", false);
            
        }

        public override void onHandleInput()
        {
            input = Input.GetAxisRaw("Horizontal");
            if (input==0)
            {
                hero.IDL();
            }
        }

        public override void onLogicUpdate()
        {
            if (input<0)
            {
                sprite.flipX = true;
            }
            if (input>0)
            {
                sprite.flipX = false;
            }
           
        }

        public override void onPhysicsUpdate()
        {
            rgb.velocity = new Vector2(speed*input, rgb.velocity.y);
        }
    }
}

