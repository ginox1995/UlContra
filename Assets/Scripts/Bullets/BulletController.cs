using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.Hero;
using ProyectoFinal.Mecha;
using ProyectoFinal.NormalRobot;

namespace ProyectoFinal.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {
        public float force;
        public float damage;
        private float currentDurability;
        private Vector3 initialPoint;
        public float maxDurability;
        public float reach;
        public Vector3 direction;
        

        void Start()
        {

            //fixDirection();
            FlipBullet();
            currentDurability = 0;
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 aux = fixDirection();
            rb.AddForce(aux * force, ForceMode.Impulse);
            
            initialPoint = this.GetComponent<Transform>().position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("colicion");
            if (collision.gameObject.CompareTag("Enemy"))
            {
                currentDurability += 1;
                if (collision.gameObject.name == "RobotEnemy")
                    collision.gameObject.GetComponent<NormalRobotController>().Damaged(damage);
                else if (collision.gameObject.name == "MechaTrooper")
                    collision.gameObject.GetComponent<MechaController>().Damaged(damage);

                //GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("ZombieShooted");
                
                //collision.gameObject.GetComponent<EnemiController>().damaged(damage);
            }
            if ((!collision.gameObject.CompareTag("Player") && currentDurability == maxDurability))
                Destroy(gameObject);

        }
        
        void FixedUpdate() 
        {
            if (Vector3.Distance(transform.position, initialPoint) >= reach)
                Destroy(gameObject);
            //fixDirection();
        }

        void FlipBullet() 
        {
            if (GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX)
                force = -force;


        }
        
        Vector3 fixDirection()
        {
            if (GameObject.Find("Hero").GetComponent<HeroController>().GetCurrentheroState() is LookingUp)
            {
                if (this.transform.root.gameObject.name == "LazerBullet(Clone)")
                    transform.Rotate(Vector3.forward, 90);
                return new Vector3(direction.y, direction.x, direction.z);
            }
            else
                return direction;
        }
        void FixLazerSprite() 
        {
            
        }
    }
}