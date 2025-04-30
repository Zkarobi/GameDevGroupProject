using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;

    void Start()
    {
        Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }
}
