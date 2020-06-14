using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;
    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        float translation = Input.GetAxis("Horizontal"); // -1 to +1
        Vector2 playerVelocity = new Vector2(translation * speed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
}
