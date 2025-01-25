using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBubble : AIShooter
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject basicBulletPrefab;

    [SerializeField]
    Vector3 front;

    [SerializeField]
    float cooldown = 1f;

    bool isTargetInShootRange = false;
    bool isChasing = false;
    bool isShooting = false;
    bool canShoot = false;
    public bool shouldChasePlayer = false;
    public bool isPlayerInRange = false;
    public bool wasAttackedByPlayer = false;

    NavMeshAgent agent;
    Rigidbody rb;
    TargetController tc;
    AcidityController acidityController;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.tc = GetComponent<TargetController>();
        this.rb = GetComponent<Rigidbody>();
        this.acidityController = GetComponent<AcidityController>();
        GetComponent<AcidityController>()
            .OnAcidityChange.AddListener(
                delegate(float acidityLevel)
                {
                    if (acidityLevel == 0)
                    {
                        GetComponentInChildren<Animator>().SetTrigger("Destroyed");
                    }
                }
            );
        this.tc.primaryTarget = GameObject
            .FindGameObjectsWithTag("Reactor")[0]
            .GetComponent<Transform>();
        this.tc.secondaryTarget = GameObject
            .FindGameObjectsWithTag("Player")[0]
            .GetComponent<Transform>();
        this.tc.target = this.tc.primaryTarget;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.wasAttackedByPlayer && this.isPlayerInRange)
        {
            if (this.canShoot)
            {
                this.agent.ResetPath();
                this.transform.LookAt(this.tc.secondaryTarget);
                Attack(this.tc.secondaryTarget);
            }
        }
        else
        {
            wasAttackedByPlayer = false;
            if (!this.isTargetInShootRange && !this.isChasing)
            {
                Chase(this.tc.primaryTarget);
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
                    if (this.canShoot)
                    {
                        Attack(this.tc.primaryTarget);
                    }
                }
            }
            else if (!this.isTargetInShootRange)
            {
                this.isShooting = false;
            }
        }

        // if (this.tc.target != null && !this.isTargetInShootRange && !this.isChasing)
        // {
        //     this.agent.SetDestination(this.tc.target.position);
        //     this.isChasing = true;
        // }
        // else if (this.isTargetInShootRange)
        // {
        //     if (this.isChasing)
        //     {
        //         this.agent.ResetPath();
        //         this.isChasing = false;
        //         this.isShooting = true;
        //         this.canShoot = true;
        //     }
        //     else
        //     {
        //         this.transform.LookAt(this.tc.target);
        //     }
        // }
        // else if (!this.isTargetInShootRange)
        // {
        //     this.isShooting = false;
        // }

        // if (this.isShooting && this.canShoot)
        // {
        //     ShootBullet();
        // }
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

    void Attack(Transform target)
    {
        this.canShoot = false;

        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector.");
            return;
        }

        GameObject bullet;

        if (acidityController.AcidityLevel > 0)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else
        {
            bullet = Instantiate(this.basicBulletPrefab, transform.position, transform.rotation);
        }

        // GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.spawnerTag = this.tag;

        float bulletSpeed = bulletComponent.Speed;
        bullet.GetComponent<Rigidbody>().velocity =
            bulletSpeed * (target.position - transform.position).normalized;

        StartCoroutine(ShootCooldown());
    }

    void Chase(Transform target)
    {
        this.agent.SetDestination(target.position);
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        this.canShoot = true;
    }

    public override void OnEnterShootRange(Collider other)
    {
        if (other.transform.parent.CompareTag(this.tc.primaryTarget.tag))
        {
            this.isTargetInShootRange = true;
        }

        if (other.transform.parent.CompareTag("Player"))
        {
            this.isPlayerInRange = true;
        }
    }

    public override void OnExitShootRange(Collider other)
    {
        if (other.transform.parent.CompareTag(this.tc.primaryTarget.tag))
        {
            this.isTargetInShootRange = false;
        }

        if (other.transform.parent.CompareTag("Player"))
        {
            this.isPlayerInRange = false;
        }
    }

    public void AttackedByPlayer()
    {
        this.wasAttackedByPlayer = true;
        if (isPlayerInRange)
        {
            // this.tc.target = this.tc.secondaryTarget;
            this.shouldChasePlayer = true;
        }
    }

    public void TargetUpdated() { }

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
