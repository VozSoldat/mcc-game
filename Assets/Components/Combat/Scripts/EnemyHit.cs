using UnityEngine;

public class EnemyHit : MonoBehaviour, IEntityHit{
    private Enemy property;

    private void Start() {
        property = GetComponent<Enemy>();
        if (property == null) 
        {
            Debug.LogError("enemy not found on: " + gameObject.name);
        }
    }
    public void ReceiveDamage(GameObject bullet)
    {
        property.Acidity += bullet.GetComponent<Bullet>().AcidDamage;
    }
}