using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class theFallenScript : MonoBehaviour
{
    public GameManager manager;
   
    public GameObject blood;
    public GameObject maviefekt;
    public GameObject angelscreen;
    public GameObject spearthrower;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Collider2D cldr;
    private bool isMovingright;
    private bool isMovingleft;
    private float horizontalmove;
    public float killscore = 0;
    public Text killscoretext;
    public bool isplayerdead = false;
    private bool kontrol;
    

    public GameObject testobje;
    


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
       

        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<Collider2D>();

        isMovingleft = false;
        isMovingright = false;
        isplayerdead = false;
    }

    public void PointerDownLeft()
    {
        isMovingleft = true;
        transform.localScale = new Vector3(-0.4f, 0.4f, 0.3f);
    }

    public void PointerUpLeft()
    {
        isMovingleft = false;
        transform.localScale = new Vector3(-0.4f, 0.4f, 0.3f);
    }

    public void PointerDownRight()
    {
        isMovingright = true;
        transform.localScale = new Vector3(0.4f, 0.4f, 0.3f);

    }

    public void PointerUpRight()
    {
        isMovingright = false;
        transform.localScale = new Vector3(0.4f, 0.4f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();


        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMovingleft = true;
            isMovingright = false;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isMovingright = true;
            isMovingleft = false;
        }
        else
        {
            isMovingright = false;
            isMovingleft = false;
        }*/

        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            isplayerdead = true;
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);

            manager.GameOverScreenActive();
            
        }

        if (collision.gameObject.CompareTag("EzEnemy"))
        {
            killscore = killscore + 1;
            killscoretext.text = killscore.ToString();
            Instantiate(maviefekt, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Angel"))
        {
            kontrol = true;
            
            
            cldr.enabled = false;
            angelscreen.SetActive(true);
            Invoke("AngelHelpOff", 5f);
            if(kontrol == false)
            {
                Destroy(collision.gameObject);
            }

        }

        if (collision.gameObject.CompareTag("SpearAmmo"))
        {
            Destroy(collision.gameObject);
            spearthrower.SetActive(true);
            Invoke("SpearThrowerOff", 5f);

        }


    }

    void AngelHelpOff()
    {
        angelscreen.SetActive(false);
        cldr.enabled = true;
        
        kontrol = false;
        
    }

    void SpearThrowerOff()
    {
        spearthrower.SetActive(false);

    }





}
