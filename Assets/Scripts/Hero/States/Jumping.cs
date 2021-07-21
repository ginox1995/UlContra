using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Hero
{
    public class Jumping : HeroState
    {
        private float jumpspeed;
        private float runningspeed;
        private bool isJumping;
        private Rigidbody rgb;
        private SpriteRenderer sprite;
        private Animator animHero;
        private float input;
        private BoxCollider boxcollider;
        private CapsuleCollider capsulecollider;
        public Jumping(HeroController hero, HeroStateMachine herosfm) : base(hero, herosfm)
        {
            jumpspeed = hero.jumpspeed;
            runningspeed = hero.runningspeed;
            rgb = hero.GetComponent<Rigidbody>();
            sprite = hero.GetComponent<SpriteRenderer>();
            animHero = hero.GetComponent<Animator>();
            boxcollider = hero.GetComponent<BoxCollider>();
            capsulecollider = hero.GetComponent<CapsuleCollider>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            isJumping = true;
            if (Input.GetKeyDown(KeyCode.Space) && hero.IsGrounded())
            {

                rgb.AddForce(new Vector3(runningspeed * input, jumpspeed, 0), ForceMode.Impulse);
                Debug.Log("SE EJECUTA");
                //rgb.velocity = new Vector3(rgb.velocity.x, jumpspeed,0);
            }
            boxcollider.enabled = false;
            capsulecollider.enabled = true;
            animHero.SetBool("Jumping", true); 
            
        }

        public override void OnExit()
        {
            base.OnExit();
            boxcollider.enabled = true;
            capsulecollider.enabled = false;
            animHero.SetBool("Jumping", false);
            
        }

        public override void onHandleInput()
        {
            base.onHandleInput();
            input = Input.GetAxisRaw("Horizontal");
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
            Debug.Log(hero.IsGrounded());
            if (rgb.velocity.y<0)
            {
                isJumping = false;
            }
            if (hero.IsGrounded() && !isJumping)
            {
                hero.IDL();
            }
            else if (hero.IsGrounded() && input!=0 && !isJumping)
            {
                hero.Run();
            }

        }

        public override void onPhysicsUpdate()
        {
            base.onPhysicsUpdate();
            rgb.velocity = new Vector3(input * runningspeed, rgb.velocity.y,0);
            
        }
    }
}

