using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.NormalRobot
{
    public class DyingState : NormalRobotState
    {
        Animator animRobot;
        Rigidbody rgb;
        public DyingState(NormalRobotController normalrobot, NormalRobotStateMachine fsm) : base(normalrobot, fsm)
        {
            animRobot = normalrobot.GetComponent<Animator>();
            rgb = normalrobot.GetComponent<Rigidbody>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rgb.velocity = Vector3.zero;
            animRobot.SetTrigger("isDead");
        }
    }
}

