using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidePaths : MonoBehaviour
{

    public bool goingRight;
    public float speed;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingRight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else if (goingRight == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.y >= gameManager.verticalScreenSize * 1.25f || transform.position.y <= -gameManager.verticalScreenSize * 1.25f)
        {
            Destroy(this.gameObject);
        }
    }
}
