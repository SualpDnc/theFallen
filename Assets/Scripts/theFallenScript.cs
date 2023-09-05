using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theFallenScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isMovingright;
    private bool isMovingleft;
    private float horizontalmove;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMovingleft = false;
        isMovingright = false;

    }

    public void PointerDownLeft()
    {
        isMovingleft = true;
    }

    public void PointerUpLeft()
    {
        isMovingleft = false;
    }

    public void PointerDownRight()
    {
        isMovingright = true;
    }

    public void PointerUpRight()
    {
        isMovingright = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (isMovingleft)
        {
            horizontalmove = -moveSpeed;
        }
        else if(isMovingright)
        {
            horizontalmove = moveSpeed;
        }
        else
        {
            horizontalmove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalmove, rb.velocity.y);
    }




}
