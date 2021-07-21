using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Mecha
{
    public class Dying : MechaState
    {
        private Animator anim;
        private Rigidbody rgb;
        public Dying(MechaController mecha, MechaStateMachine fsm) : base(mecha, fsm)
        {
            anim = mecha.GetComponent<Animator>();
            rgb = mecha.GetComponent<Rigidbody>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rgb.velocity = Vector3.zero;
            anim.SetTrigger("isDying");
        }
    }
}

