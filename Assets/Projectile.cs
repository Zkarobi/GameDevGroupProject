using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Auto-destroy after X seconds
    }

        private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Projectile triggered with: " + other.name);

        if (other.CompareTag("Boss"))
        {
            Boss boss = other.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
                Debug.Log("Boss took damage!");
            }
        }

        Destroy(gameObject); // Destroy projectile on impact
    }
}

