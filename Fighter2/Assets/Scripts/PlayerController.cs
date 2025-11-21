using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives;

    public int livesMax;

    private float speed;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.5f;
    private float verticalScreenLimit = 3.5f;

    private float yLimitUp = 0.85f;
    private float yLimitDown = -3.5f;


    public GameObject bulletPrefab;
    public GameObject BulletSpecialPrefab;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        livesMax = 4;
        speed = 5.0f;
        gameManager.ChangeLivesText(lives);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Movement();
        Shooting();
    }

    [System.Obsolete]
    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //search for audio and apply it without needing to add it to script
            FindObjectOfType<AudioManager>().Play("PlaneDeath");
            Destroy(this.gameObject);
        }
    }
[System.Obsolete]
     public void GainALife() //This was done by Jordon Dubin
    {
        
        lives++;
        //FindObjectOfType<AudioManager>().Play("Heart");

        // Debug.Log($"Player lives: {lives}"); How to check Lives
        if (lives >= livesMax) //compares lives to max lives to internally limit it
        {
            lives = 3;

            //adds 50 to score
            ScoreManager.instance.AddScore(50);
        }
        //updates lives text after checking lives number ^
        gameManager.ChangeLivesText(lives);
    }

    [System.Obsolete]
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
        
        // Freddie Added unique bullet mechanic
         if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(BulletSpecialPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Coins")
        {
            FindObjectOfType<AudioManager>().Play("Coin");   
        }
        if (whatDidIHit.tag == "Lives")
        {
            FindObjectOfType<AudioManager>().Play("Heart");

        }
    }




    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
      
        //stop player from moving off screen and getting to enemies
        //Freeze movement downwards making the player only able to move up, left and right
         if(transform.position.y <= -verticalScreenLimit)
        {
                        transform.position = new Vector3(transform.position.x, yLimitDown, transform.position.z);

        }
         
         //freeze movement upwards making player only able to move down, left and right
         if(transform.position.y > verticalScreenLimit/4 )
        {
            transform.position = new Vector3(transform.position.x, yLimitUp, transform.position.z);


        }


    }
}
