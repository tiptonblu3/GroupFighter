using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public bool goingUp;
    public float speed;
    public bool shooting;
    public float spawnDelay = 0.2f;
    public GameObject bulletPrefab;


    private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (goingUp == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (shooting)
        {
            // Start the coroutine to spawn bullets
            StartCoroutine(SpawnBullets());
            shooting = false; // Prevent continuous spawning while shooting is true

        }

        if (transform.position.y >= gameManager.verticalScreenSize * 1.25f || transform.position.y <= -gameManager.verticalScreenSize * 1.25f)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator SpawnBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            // Instantiate the bullet at the current position with a 180-degree rotation on the X-axis
            Quaternion rotation = Quaternion.Euler(180f, 0f, 0f); // Rotation on X-axis (180 degrees)
            Instantiate(bulletPrefab, transform.position, rotation);

            // Wait for the specified delay before spawning the next bullet
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}