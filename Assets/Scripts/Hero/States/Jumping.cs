using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Hero
{
    public class Jumping : HeroState
    {
        private float jumpspeed;
        private Rigidbody2D rgb;
        private SpriteRenderer sprite;
        private Animator animHero;
        private float input;
        public Jumping(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            jumpspeed = hero.jumpspeed;
            rgb = hero.GetComponent<Rigidbody2D>();
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            animHero.SetBool("Jumping", true);
        }

        public override void OnExit()
        {
            base.OnExit();
            animHero.SetBool("Jumping", false);
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            if (input < 0)
            {
                sprite.flipX = true;
            }
            if (input > 0)
            {
                sprite.flipX = false;
            }
        }
        public override void onLogicUpdate()
        {
            base.onLogicUpdate();
        }

        public override void onPhysicsUpdate()
        {
            base.onPhysicsUpdate();
            
        }
    }
}

