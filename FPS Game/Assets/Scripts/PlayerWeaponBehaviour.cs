using UnityEngine;

public class PlayerWeaponBehaviour : MonoBehaviour
{
    public GameObject _projectilePrefab;
    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit; 
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                FireWeapon(hit);
            }
        }
    }

    private void FireWeapon(RaycastHit hit)
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = hit.point;
        projectile.transform.parent = hit.transform;

        if(hit.transform.tag == "Enemy")
        {
            EnemyBehaviour enemy = hit.transform.GetComponent<EnemyBehaviour>();
            enemy.Hit();
        }
    }
}
