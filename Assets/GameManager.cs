using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hero;
    public Transform[] spawnEnemyPosition;
    public Transform[] checkSpawnEnemy;
    public Transform[] spawnMechaPosition;
    public Transform[] checkSpawnMecha;

    public GameObject prefabEnemy;
    public GameObject prefabMecha;

    public bool[] enemyInstantiated;
    public bool[] mechaInstantiated;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < checkSpawnEnemy.Length; i++)
        {
            if (hero.position.x > checkSpawnEnemy[i].position.x && enemyInstantiated[i] == false)
            {
                //Debemos spawnear enemigos
                Instantiate(prefabEnemy, spawnEnemyPosition[i].position, prefabEnemy.transform.rotation);
                enemyInstantiated[i] = true;
            }
        }
        for (int i = 0; i < checkSpawnMecha.Length; i++)
        {
            if (hero.position.x > checkSpawnMecha[i].position.x && mechaInstantiated[i] == false)
            {
                Instantiate(prefabMecha, spawnMechaPosition[i].position, prefabMecha.transform.rotation);
                mechaInstantiated[i] = true;
            }
        }
    }
}
