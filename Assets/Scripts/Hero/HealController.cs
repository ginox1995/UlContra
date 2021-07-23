using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProyectoFinal.Hero
{
    public class HealController : MonoBehaviour
    {
        public Vector3 startPosition;
        public Vector3 startScale;
        

        void Start()
        {
            //transform.localPosition = startPosition;
            //transform.localScale = startScale;
        }

        // Start is called before the first frame update
        public void HealModification(float currentHeal, float damage)
        {
            Debug.Log("aaa  ");
            Vector3 currentelocalScale = transform.localScale;
            Vector3 currenteLocalPosition = transform.localPosition;

            float reduccion = currentHeal / 10f;

            transform.localScale = new Vector3(currentelocalScale.x * reduccion, currentelocalScale.y, currentelocalScale.z);

            transform.localPosition = new Vector3(currenteLocalPosition.x - ((currenteLocalPosition.x * reduccion) / 2f), currenteLocalPosition.y, currenteLocalPosition.z);

        }
    }
}