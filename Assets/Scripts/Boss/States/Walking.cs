using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Boss
{
    public class Walking : BossState
    {
        private Rigidbody rgb;
        private Animator anim;
        public Walking(BossController controller, BossStateMachine fsm) : base(controller, fsm)
        {
            rgb = controller.GetComponent<Rigidbody>();
            anim = controller.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            anim.SetBool("isWalking", true);

        }

        public override void OnExit()
        {
            base.OnExit();
            anim.SetBool("isWalking", false);
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
            if (rgb.transform.position.x<=controller.limitWalk.position.x)
            {
                controller.Jump();
            }
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
            rgb.velocity = new Vector3(-controller.bossSpeed, rgb.velocity.y, rgb.velocity.z);
        }
    }
}

