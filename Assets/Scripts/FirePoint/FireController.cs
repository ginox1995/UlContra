using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProyectoFinal.Bullets;
using ProyectoFinal.Hero;
using System;


namespace ProyectoFinal.FirePoint
{
    public class FireController : MonoBehaviour
    {
        private GameObject selectedWeapon;
        private float fireRate;
        private float countdown = 0.0f;
        public string defaultWeapon;
        public Bullet[] bullets;
        public FirePointPosition[] firePoints;
        private string animationAttribute;

        private bool fliped;

        void Start()
        {
            WeaponSelection(defaultWeapon);
            fliped = GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX;
            //animationAttribute = GameObject.Find("Hero").GetComponent<HeroController>().fms.currentState;
        }

        public void Fire()
        {
            if (countdown < Time.time)
            {
                //Debug.Log("F");
                countdown = Time.time + fireRate;
                Instantiate(selectedWeapon, this.transform.position, this.transform.rotation);
            }
        }

        public void WeaponSelection(string name)
        {
            Bullet b = Array.Find(bullets, bullet => bullet.name == name);
            selectedWeapon = b.bulletPrefab;
            fireRate = b.fireRate;
        }
         
        void FixedFit()
        {
            transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z); 
        }
        /*
        void FixedUpdate()
        {
            Debug.Log(fliped);
            Debug.Log(GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX);
            if (fliped != GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX)
            {
                fliped = GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX;
                //FixPosition(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));
                FixPosition(transform.localPosition);
                
            }
        }
        */
        public void FixPosition(bool flip) 
        {
            fliped = flip;
            Vector3 aux = transform.localPosition;
            aux.x = (flip) ? -aux.x : aux.x;
            transform.localPosition = aux;
        }

        public void FixTransforme(string animationAttribute)
        {
            FirePointPosition fPos = Array.Find(firePoints, firePoint => firePoint.animationAttribute == animationAttribute);
            float m = (GameObject.Find("Hero").GetComponent<SpriteRenderer>().flipX) ? -1 : 1;
            Vector3 aux = new Vector3(m*fPos.firePointPosition.x,fPos.firePointPosition.y,fPos.firePointPosition.z);
            transform.localPosition = aux;
        }


    }
}