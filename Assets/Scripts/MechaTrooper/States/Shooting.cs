using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Mecha
{
    public class Shooting : MechaState
    {
        private Rigidbody rgb;
        private Animator anim;
        private float firerate = 3f;
        private float nextfire = 0f;
        public Shooting(MechaController mecha, MechaStateMachine fsm) : base(mecha, fsm)
        {
            rgb = mecha.GetComponent<Rigidbody>();
            anim = mecha.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            anim.SetBool("enemySpotted", true);

        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
            if (Time.time>nextfire)
            {
                nextfire = Time.time + firerate;
                mecha.Fire();
            }
            if (!mecha.EnemyOnSight())
            {
                mecha.Patroling();
            }
            if (mecha.mechaHP<=0)
            {
                mecha.Dying();
            }
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
            rgb.velocity = Vector3.zero;
        }
    }
}

