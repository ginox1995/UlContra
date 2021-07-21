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
        //public string animationAttribute = "Jumping";

        public Jumping(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            jumpspeed = hero.jumpspeed;
            rgb = hero.GetComponent<Rigidbody2D>();
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
            this.animationAttribute = "Jumping";    
        }

        public override void OnEnter()
        {
            base.OnEnter();
            animHero.SetBool(animationAttribute, true);
        }

        public override void OnExit()
        {
            base.OnExit();
            animHero.SetBool(animationAttribute, false);
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

