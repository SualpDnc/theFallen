using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMoveScript : MonoBehaviour
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
        transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;

        if (transform.position.y < -deadzone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hrrhngbçrpma");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemyçrpma");
            Destroy(collision.gameObject);
        }

        
    }
}
