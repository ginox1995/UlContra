using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProyectoFinal.Mecha
{
    public class MechaController : MonoBehaviour
    {
        private MechaStateMachine fsm;
        public float mechaSpeed;
        public float mechaHP;
        public float missileSpeed;
        private BoxCollider boxcollider;
        [SerializeField] private LayerMask heroLayer;
        [SerializeField] private Transform missileSpawnLocation;
        [SerializeField] private Rigidbody missile;
        //States
        private Patrolling patrolling;
        private Shooting shooting;
        private Dying dying;
        void Start()
        {
            fsm = new MechaStateMachine();
            //States
            patrolling = new Patrolling(this, fsm);
            shooting = new Shooting(this, fsm);
            dying = new Dying(this, fsm);
            //Others
            boxcollider = GetComponent<BoxCollider>();
            fsm.Start(patrolling);
        }
        void Update()
        {
            fsm.getMechaState().OnLogicUpdate();
            EnemyOnSight();
            
        }
        private void FixedUpdate()
        {
            fsm.getMechaState().OnPhysicsUpdate();
        }
        public void Shooting()
        {
            fsm.ChangeState(shooting);
        }
        public void Dying()
        {
            fsm.ChangeState(dying);
        }
        public void Patroling()
        {
            fsm.ChangeState(patrolling);
        }
        public void Fire()
        {
            var misil= Instantiate(missile, missileSpawnLocation.position, missileSpawnLocation.rotation);
            misil.AddForce( new Vector3(-1,0,0)*missileSpeed,ForceMode.Impulse);
        }
        public bool EnemyOnSight()
        {
            float extension = 150f;
            bool hit;
            Color color;
            hit=Physics.Raycast(boxcollider.bounds.center, Vector3.left * (boxcollider.bounds.extents.x+extension),heroLayer);
            if (hit)
            {
                color = Color.green;
            }
            else
            {
                color = Color.red;
            }
            Debug.DrawRay(boxcollider.bounds.center, Vector3.left * (boxcollider.bounds.extents.x + extension), color);
            return hit;
            
        }

    }
}

