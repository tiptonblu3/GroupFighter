using UnityEngine;

public class Coins : MonoBehaviour
{

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            ScoreManager.instance.AddScore(250);
            FindObjectOfType<AudioManager>().Play("Coin");
            Destroy(this.gameObject);
        }
    }

}
