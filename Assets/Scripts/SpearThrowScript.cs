using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowScript : MonoBehaviour
{

    public GameObject spear;
    public float spawnRate = 2;
    private float timer = 0;
    public float offset = 2.66f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnSpear();
            timer = 0;
        }
    }

    void spawnSpear()
    {
     

        Instantiate(spear, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

    }
}
