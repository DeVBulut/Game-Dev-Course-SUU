using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour
{
    public override void Die()
    {
        transform.Rotate(-75f, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerController.Instance.transform);
    }
}
