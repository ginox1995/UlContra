using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem fire;
    private float cooldownTime;
    private float attackDuration;
    private bool fireOn = false;
    void Start()
    {
        cooldownTime = 5f;
        attackDuration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //fire.Play();
        if (cooldownTime<7f)
        {
            cooldownTime += Time.deltaTime;
        }
        if (cooldownTime>=7f)
        {
            attackDuration += Time.deltaTime;
            fireOn = true;
        }
        else
        {
            fireOn = false;
        }
        if (attackDuration>=5f)
        {
            cooldownTime = 0f;
            attackDuration = 0f;
        }

        if (fireOn)
        {
            fire.Play();
        }
        else
        {
            fire.Stop();
        }
        Debug.Log(attackDuration);
        Debug.Log(fireOn);

    }
}
