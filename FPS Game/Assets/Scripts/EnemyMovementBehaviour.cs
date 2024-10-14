using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _player;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Turn the enemy 90 degrees upon colliding with any object
        if (collision.gameObject.GetComponent<Collider>() != null)
        {
            transform.Rotate(0, 45, 0);
        }
    }

    private void ChasePlayer()
    {
        RaycastHit hit;
        Vector3 toPlayer = PlayerController.Instance.transform.position - transform.position;
        Physics.Raycast(transform.position, toPlayer, out hit);
        if (hit.transform.tag != "Player") return;
        transform.LookAt(PlayerController.Instance.transform);
    }

}