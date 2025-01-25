using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int physicalDamage = 1;

    [SerializeField]
    private int acidDamage = -1;

    [SerializeField]
    private float bulletSpeed = 50;

    public String spawnerTag;

    public float Speed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }
    public int PhysicalDamage
    {
        get => physicalDamage;
        set => physicalDamage = value;
    }
    public int AcidDamage
    {
        get => acidDamage;
        set => acidDamage = Math.Clamp(value, -7, 7);
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject.GetComponentInParent<IEntityHit>();
        Debug.Log("Bullet hit: " + other.gameObject.transform.parent.name);
        if (target != null && !other.transform.parent.CompareTag(this.spawnerTag))
        {
            target.ReceiveDamage(this.gameObject);
        }

        if (!other.transform.parent.CompareTag(this.spawnerTag) && !other.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
