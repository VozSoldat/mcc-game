using UnityEngine;

public class PlayerHit: MonoBehaviour, IEntityHit{
    private IEntity property;

    private void Start() {
        property = GetComponent<IEntity>();
        if (property == null) 
        {
            Debug.LogError("EntityHit not found on: " + gameObject.name);
        }
    }
    public void ReceiveDamage(GameObject bullet)
    {
        property.Health -= bullet.GetComponent<Bullet>().PhysicalDamage;
        Debug.Log(bullet.gameObject.name);
        Debug.Log("health: " + property.Health);
    }
}