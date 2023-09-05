using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnRate = 2;
    private float timer = 0;
    public float offset = 2.66f;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0;
        }
    }

    void spawnEnemy()
    {
        float leftpoint = transform.position.x - offset;
        float rightpoint = transform.position.x + offset;
        Instantiate(enemy, new Vector3(Random.Range(leftpoint,rightpoint), transform.position.y, 0), transform.rotation);
    }
}
