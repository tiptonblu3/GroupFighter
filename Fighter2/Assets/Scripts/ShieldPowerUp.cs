using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 4);
    }
    public GameObject ShieldPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(ShieldPrefab);  // Spawn Shield
            Destroy(gameObject);            // destroy shield Pick Up
        }
    }
}