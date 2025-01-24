using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBubble : AIShooter
{
    public Transform target;

    bool isTargetInShootRange = false;
    bool isChasing = false;

    NavMeshAgent agent;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.target != null && !this.isTargetInShootRange && !this.isChasing)
        {
            this.agent.SetDestination(target.position);
            this.isChasing = true;
        }
        else if (this.isTargetInShootRange && this.isChasing)
        {
            this.agent.ResetPath();
            this.isChasing = false;
        }
    }
    public override void OnEnterShootRange(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.isTargetInShootRange = true;
        }
    }

    public override void OnExitShootRange(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.isTargetInShootRange = false;
        }
    }
}
