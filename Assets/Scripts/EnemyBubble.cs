using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBubble : AIShooter
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Vector3 front;

    [SerializeField]
    float cooldown = 1f;

    bool isTargetInShootRange = false;
    bool isChasing = false;
    bool isShooting = false;
    bool canShoot = false;

    NavMeshAgent agent;
    Rigidbody rb;
    TargetController tc;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.tc = GetComponent<TargetController>();
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.tc.target != null && !this.isTargetInShootRange && !this.isChasing)
        {
            this.agent.SetDestination(this.tc.target.position);
            this.isChasing = true;
        }
        else if (this.isTargetInShootRange)
        {
            if (this.isChasing)
            {
                this.agent.ResetPath();
                this.isChasing = false;
                this.isShooting = true;
                this.canShoot = true;
            }
            else
            {
                this.transform.LookAt(this.tc.target);
            }
        }
        else if (!this.isTargetInShootRange)
        {
            this.isShooting = false;
        }

        if (this.isShooting && this.canShoot)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        this.canShoot = false;

        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.spawnerTag = this.tag;

        float bulletSpeed = bulletComponent.Speed;
        bullet.GetComponent<Rigidbody>().velocity =
            bulletSpeed * (this.tc.target.position - transform.position).normalized;

        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        this.canShoot = true;
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
