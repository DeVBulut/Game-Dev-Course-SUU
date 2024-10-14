using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] GameObject _wallObject;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) input += Vector3.left;
        if (Input.GetKey(KeyCode.D)) input += Vector3.right;
        if (Input.GetKey(KeyCode.W)) input += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) input += Vector3.back;

        input = input.normalized;
        //Debug.Log(input.magnitude);
        
        Vector3 velocity = 
            (transform.forward * input.z + 
            transform.right * input.x) * _speed;
        
        _rigidbody.linearVelocity = velocity;
     }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag != "End") return;
    Debug.Log("OH HEY! YOU WIN!");
}

}
