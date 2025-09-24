using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            health -= other.GetComponent<PlayerAttack>().damage;

            if(health <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
