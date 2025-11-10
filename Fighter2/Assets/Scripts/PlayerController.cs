using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives;
    private float speed;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 5.5f;
    private float verticalScreenLimit = 3.5f;


    public GameObject bulletPrefab;
    public GameObject BulletSpecialPrefab;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
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
        if (transform.position.x > horizontalScreenLimit / 2 || transform.position.x <= -horizontalScreenLimit / 2)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
      
        //stop player from moving off screen and getting to enemies


        //Portion Jordon Did
        
        if(transform.position.y > verticalScreenLimit/8 || transform.position.y <= -verticalScreenLimit/2)
        {
            transform.position = new Vector3(0,0,0);

        }
       



    }
}
