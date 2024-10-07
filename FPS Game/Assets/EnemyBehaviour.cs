using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Hit()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            transform.Rotate(-75f, 0f, 0f);
        }
    }
}


