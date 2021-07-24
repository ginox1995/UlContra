using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

    }
}
