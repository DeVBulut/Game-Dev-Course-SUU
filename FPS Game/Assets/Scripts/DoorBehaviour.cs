using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Color DoorColor;
    bool _playerInRange;
    [SerializeField] private KeyBehaviour keyForDoor;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = DoorColor; 
        keyForDoor.GetComponent<MeshRenderer>().material.color = DoorColor;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            foreach(KeyBehaviour key in PlayerController.instance.KeysCollected)
            {
                if(key == keyForDoor)
                {
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = true;
        Debug.Log("Door.com");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = false;
    }
}
