using UnityEngine;

public class EnemyHit : MonoBehaviour, IEntityHit
{
    private Enemy property;
    AcidityController acidityController;
    TargetController targetController;

    private void Start()
    {
        this.acidityController = GetComponentInParent<AcidityController>();
        this.targetController = GetComponentInParent<TargetController>();
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
        // Debug.Log("Acidity: " + acidityController.AcidityLevel);
        // Debug.Log("Bullet acid damage: " + bullet.GetComponent<Bullet>().AcidDamage);

        if (acidityController.AcidityLevel == 0)
        {
            GetComponentInChildren<Animator>().SetTrigger("Destroyed");
        }

        if (bullet.GetComponent<Bullet>().spawnerTag.Equals("Player"))
        {
            this.targetController.target = GameObject.FindGameObjectWithTag("Player").transform;
            GetComponent<EnemyBubble>().AttackedByPlayer();
        }
    }

    private void DestroySelf()
    {
        // Debug.Log("Acidity: " + acidityController.AcidityLevel);
        Destroy(gameObject);
    }
}
