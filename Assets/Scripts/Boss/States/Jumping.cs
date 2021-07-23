using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Boss
{
    public class Jumping : BossState
    {
        private Rigidbody rgb;
        private Animator anim;
        public Jumping(BossController controller, BossStateMachine fsm) : base(controller, fsm)
        {
            rgb = controller.GetComponent<Rigidbody>();
            anim = controller.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
        }
    }
}

