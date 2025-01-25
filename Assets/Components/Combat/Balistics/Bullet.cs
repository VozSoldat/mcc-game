using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 playerPosition;
    [SerializeField] private float boundDistance = 50f;
    [SerializeField] private int physicalDamage = 1;
    [SerializeField] private int acidDamage = -1;
    [SerializeField] private float bulletSpeed = 50;
    public float Speed { get { return bulletSpeed; } set { bulletSpeed = value; } }
    public int PhysicalDamage { get => physicalDamage; set => physicalDamage = value; }
    public int AcidDamage { get => acidDamage; set => acidDamage = Math.Clamp(value, -7, 7); }

    private void Start()
    {
        playerPosition = GameObject.Find("Player").transform.position;
    }

    private void Update()
    {
        
        if ((playerPosition - transform.position).magnitude > boundDistance)
        {
            DestroySelf();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var target = other.gameObject.GetComponent<IEntityHit>();
        if (target != null)
        {
            target.ReceiveDamage(this.gameObject);
        }

        DestroySelf();
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}