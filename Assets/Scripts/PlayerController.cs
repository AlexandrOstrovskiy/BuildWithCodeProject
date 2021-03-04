using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private float speed = 200.0f;

    private float topBound = 10.0f;
    private float bottomBound = -10.0f;
    private float leftBound = -10.0f;
    private float rightBound = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalIntup = Input.GetAxis("Vertical");

        playerRigidbody.AddForce(Vector3.forward * speed * verticalIntup * Time.deltaTime);
        playerRigidbody.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(0, Random.Range(30, 210), 0);
            playerRigidbody.AddForce(Vector3.forward * speed * 100 * Time.deltaTime);
        }

    }
}
