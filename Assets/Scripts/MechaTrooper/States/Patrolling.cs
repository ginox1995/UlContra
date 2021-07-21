using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Mecha
{
    public class Patrolling : MechaState
    {
        private Rigidbody rgb;
        private Animator anim;
        public Patrolling(MechaController mecha, MechaStateMachine fsm) : base(mecha, fsm)
        {
            rgb = mecha.GetComponent<Rigidbody>();
            anim = mecha.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            anim.SetBool("enemySpotted", false);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
            if (mecha.EnemyOnSight())
            {
                mecha.Shooting();
            }
            if (mecha.mechaHP<=0)
            {
                mecha.Dying();
            }
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
            rgb.velocity=new Vector3(-mecha.mechaSpeed, rgb.velocity.y, 0);
        }
    }
}

