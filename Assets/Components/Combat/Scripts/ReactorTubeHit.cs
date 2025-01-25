using UnityEngine;

public class ReactorTubeHit : MonoBehaviour, IEntityHit
{
    private ReactorTube property;

    private void Start() {
        property = GetComponent<ReactorTube>();
        if (property == null) 
        {
            Debug.LogError("reactor not found on: " + gameObject.name);
        }
    }
    public void ReceiveDamage(GameObject bullet)
    {
        property.Health -= bullet.GetComponent<Bullet>().PhysicalDamage;
        Debug.Log("Health: " + property.Health);
        if (property.Health <= 0)
        {
            Die();
        }
    }
    private void Die(){
        Debug.Log(gameObject.name + " mati");
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}