using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public GameObject enemyGroup;
    private bool isPlaying = true;

    public void OffSpawner()
    {
        isPlaying = false;
    }

    void Update()
    {
        if (isPlaying)
        {
            int spawnPer = Random.Range(0, 1001);
            if(spawnPer < 10)
            {
                Enemy e = Instantiate(enemy);

                float posY = Random.Range(-8f, 8f);
                int isLeftInstantiate = Random.Range(0, 2);

                if (isLeftInstantiate == 0)
                {
                    e.transform.position = new Vector3(-8.7f, posY, -1);
                    e.transform.rotation = new Quaternion(0, 0, 0, 0);
                    e.SetDirectionVector(1);
                }
                else
                {
                    e.transform.position = new Vector3(8.7f, posY, -1);
                    e.transform.rotation = new Quaternion(0, 0, 180, 0);
                    e.SetDirectionVector(-1);
                }
                e.transform.parent = enemyGroup.transform;
            }
        }
    }
}
