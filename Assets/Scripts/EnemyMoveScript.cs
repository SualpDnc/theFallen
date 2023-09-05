using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{

    public float speed;

    private float deadzone = 6.37f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;

        if(transform.position.y > deadzone)
        {
            Destroy(gameObject);
        }
    }
}
