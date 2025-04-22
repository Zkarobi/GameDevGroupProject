using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public GameObject brokenWallPrefab;

    void Update()
    {
        // TEMP TEST: Press 'T' while the wall is selected to break it
        if (Input.GetKeyDown(KeyCode.T))
        {
            DestroyWall();
        }
    }

    public void DestroyWall()
    {
        // Adjust Y offset if the prefab spawns too high
        Vector3 adjustedPos = transform.position + new Vector3(-11f, -10.5f, -4.5f); // tweak -1f as needed
        Instantiate(brokenWallPrefab, adjustedPos, transform.rotation);
        Destroy(gameObject);
    }

    /*Optional: auto-destroy on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile") || collision.gameObject.CompareTag("BossAttack"))
        {
            DestroyWall();
        }
    }
    */
}
