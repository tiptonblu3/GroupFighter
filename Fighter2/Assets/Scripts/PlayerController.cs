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

    private float horizontalScreenLimit = 7.5f;
    private float verticalScreenLimit = 3.5f;


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
    void Update()
    {
        Movement();
        Shooting();
    }

    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

     public void GainALife() //This was done by Jordon
    {
        //lives = lives - 1;
        //lives -= 1;
        lives++;

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

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        
        // Freddie Added unique bullet mechanic
         if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(BulletSpecialPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
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


        //Portion Jordon Did
        
        if(transform.position.y > verticalScreenLimit/4 || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(0,0,0);

        }
       



    }
}
