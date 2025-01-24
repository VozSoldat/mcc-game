using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int physicalDamage = 1;
    [SerializeField] private int acidDamage = -1;
    [SerializeField] private float bulletSpeed = 50;
    public float Speed { get { return bulletSpeed; } set { bulletSpeed = value; } }
    public int PhysicalDamage { get => physicalDamage; set => physicalDamage = value; }
    public int AcidDamage { get => acidDamage; set => acidDamage = Math.Clamp(value, -7, 7); }

    private void OnCollisionEnter(Collision other)
    {
        var target = other.gameObject.GetComponent<EntityHit>();
        if (target != null)
        {
            target.ReceiveDamage(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}