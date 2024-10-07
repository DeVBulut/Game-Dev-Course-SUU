using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
            movementDirection += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.A))
            movementDirection += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.S))
            movementDirection += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.D))
            movementDirection += Vector3.right;
        transform.position +=
            (movementDirection.z * transform.forward +
            movementDirection.x * transform.right) *
            _movementSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EndPoint")
        {
            Debug.Log("Hello!");
        }
    }
}
