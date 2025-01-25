using UnityEngine;

public class ReactorHit : MonoBehaviour, IEntityHit
{
    private BubbleReactor property;

    private void Start() {
        property = GetComponent<BubbleReactor>();
        if (property == null) 
        {
            Debug.LogError("reactor not found on: " + gameObject.name);
        }
    }
    public void ReceiveDamage(GameObject bullet)
    {
        property.Acidity += bullet.GetComponent<Bullet>().AcidDamage;
        Debug.Log("Acidity: " + property.Acidity);
    }
}