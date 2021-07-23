using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Bullets
{
    [System.Serializable]
    public class Bullet
    {
        public string name;

        [Range(0f, 1f)]
        public float fireRate;

        //[HideInInspector]
        public GameObject bulletPrefab;
    }
}