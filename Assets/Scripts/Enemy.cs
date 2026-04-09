using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public float damage = 10f;
    public float health = 100f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(GameManager.Instance.Target.position);
        }
        else
        {
            Debug.LogWarning("Agent not on NavMesh!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        if (dmg <= 0) return;

        health = Mathf.Max(health - dmg, 0);
    }
}
