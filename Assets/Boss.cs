using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public enum State { Idle, Attack }
    public State currentState = State.Idle;

public GameObject projectilePrefab;
public Transform projectileSpawnPoint;
public float projectileSpeed = 10f;
public float projectileArcHeight = 5f;

    public float health = 100f;
    public float attackDamage = 10f;
    public float attackCooldown = 1f;
    public float detectionRange = 10f;
    public float stopDistance = 2f;

    private float lastAttackTime;
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        currentState = State.Idle;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
            return;
        }

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                currentState = State.Attack;

                if (distanceToPlayer > stopDistance)
                {
                    // Chase the player
                    agent.SetDestination(player.transform.position);
                }
                else
                {
                    // Stop moving to attack
                    agent.ResetPath();
                    TryAttack(player);
                }
            }
            else
            {
                currentState = State.Idle;
                agent.ResetPath();
            }
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", currentState == State.Attack);
        }
    }

private void TryAttack(GameObject target)
{
    if (Time.time - lastAttackTime >= attackCooldown)
    {
        // 1. Melee touch damage
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        // 2. Ranged projectile attack
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            Vector3 targetPos = target.transform.position;
            Vector3 startPos = projectileSpawnPoint.position;

            Vector3 velocity = CalculateLobVelocity(startPos, targetPos, projectileArcHeight);

            GameObject proj = Instantiate(projectilePrefab, startPos, Quaternion.identity);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = velocity;
            }
        }

        lastAttackTime = Time.time;
    }
}


    private Vector3 CalculateLobVelocity(Vector3 start, Vector3 end, float arcHeight)
{
    Vector3 direction = end - start;
    Vector3 horizontal = new Vector3(direction.x, 0, direction.z);
    float distance = horizontal.magnitude;
    float heightDifference = direction.y;
    float gravity = Mathf.Abs(Physics.gravity.y);

    float speedY = Mathf.Sqrt(2 * gravity * arcHeight);
    float timeToPeak = speedY / gravity;
    float totalTime = timeToPeak + Mathf.Sqrt(2 * (heightDifference + arcHeight) / gravity);
    Vector3 velocityY = Vector3.up * speedY;
    Vector3 velocityXZ = horizontal / totalTime;

    return velocityXZ + velocityY;
}


    public void TakeDamage(float amount)
{
    health -= amount;

    if (health <= 0)
    {
        Die();
    }
}

private void Die()
{
    Debug.Log($"{gameObject.name} died!");
    Destroy(gameObject);
}

}

