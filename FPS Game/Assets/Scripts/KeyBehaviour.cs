using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        //PlayerController.Instance.KeysCollected.Add(this);
        gameObject.SetActive(false);
    }
}
