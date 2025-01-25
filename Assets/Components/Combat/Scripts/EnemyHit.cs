using UnityEngine;

public class EnemyHit : MonoBehaviour, IEntityHit
{
    private Enemy property;
    AcidityController acidityController;

    private void Start()
    {
        this.acidityController = GetComponentInParent<AcidityController>();
        property = GetComponent<Enemy>();
        if (property == null)
        {
            Debug.LogError("enemy not found on: " + gameObject.name);
        }
    }

    public void ReceiveDamage(GameObject bullet)
    {
        property.Acidity += bullet.GetComponent<Bullet>().AcidDamage;
        acidityController.AcidityLevel += bullet.GetComponent<Bullet>().AcidDamage;

        if (acidityController.AcidityLevel == 0)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Debug.Log("WTF");
        Debug.Log("Acidity: " + acidityController.AcidityLevel);
        Destroy(gameObject);
    }
}

