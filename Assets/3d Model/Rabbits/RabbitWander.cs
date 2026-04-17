using UnityEngine;
using UnityEngine.AI;

public class RabbitWander : MonoBehaviour
{
    public float wanderRadius = 5f;
    public float wanderTimer = 4f;
    private Vector3 homePosition; // The center of the allowed area
    private NavMeshAgent agent;
    private Animator anim;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        homePosition = transform.position; // Set current spot as "Home"
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            // Always pick a point relative to homePosition, not transform.position
            Vector3 newPos = RandomNavSphere(homePosition, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}