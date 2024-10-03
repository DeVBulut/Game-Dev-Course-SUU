using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementbehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    //[SerializeField] GameObject _wallObject;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += new Vector3(0, 0, 1); //Forward
        }
        if(Input.GetKey(KeyCode.A))
        {
            movementDirection += new Vector3(-1, 0, 0); // Left
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection += new Vector3(0, 0, -1); // Backward
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += new Vector3(1, 0, 0); // Right
        }

        transform.position +=
            (movementDirection.z * transform.forward +
            movementDirection.x * transform.right) *
            _movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag == "EndPoint")
        {
            Debug.Log("Hello");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
