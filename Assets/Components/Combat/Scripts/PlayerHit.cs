using UnityEngine;

public class PlayerHit: MonoBehaviour, IEntityHit{
    private Player property;

    private void Start() {
        property = GetComponent<Player>();
        if (property == null) 
        {
            Debug.LogError("EntityHit not found on: " + gameObject.name);
        }
    }
    public void ReceiveDamage(GameObject bullet)
    {
        property.Health -= bullet.GetComponent<Bullet>().PhysicalDamage;
    }
}