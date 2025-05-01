using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player took " + damage + " damage!");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene("GameOver"); // Loads GameOver scene
        // Add respawn, game over, etc.
    }
}

