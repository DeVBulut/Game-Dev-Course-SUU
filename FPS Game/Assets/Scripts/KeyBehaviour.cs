using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {}
        {
            other.GetComponent<PlayerController>().KeysCollected.Add(this);
            this.gameObject.SetActive(false);
        }
    }
}
