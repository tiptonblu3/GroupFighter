using UnityEngine;


    
public class Shield : MonoBehaviour
{
    public float shieldDuration = 5f;  // editable in Inspector
    private float timer = 0f;
    public Transform player;   // assign in inspector
    public float followSpeed = 20f;

    private void Start()
    {
        // Automatically find the player by tag
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Shield could not find a Player object!");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Follows player's exact position, smooth movement optional
            transform.position = Vector3.Lerp(
                transform.position, 
                player.position, 
                followSpeed * Time.deltaTime
            );
        }

        timer += Time.deltaTime;

        if (timer >= shieldDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  // destroy enemy
            Destroy(gameObject);            // destroy shield
        }
    }


}

