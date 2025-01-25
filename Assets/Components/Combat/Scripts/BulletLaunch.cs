using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    private CombatInput combatInput;
    private Vector3 aimedPosition;

    

    

    private void Start()
    {
        combatInput = GetComponent<CombatInput>();
    }

    private void Update()
    {
        // aimedPosition = GetComponent<PlayerAim>().LookDirection;

        


    }

    private void FixedUpdate()
    {
        if (combatInput.BasicAttack)
        {
            ShootBullet();
            combatInput.BasicAttack = false;
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector.");
            return;
        }

        Vector3 worldPosition = transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        

        float angle = Mathf.Atan2(Input.mousePosition.y-screenPosition.y, screenPosition.x - Input.mousePosition.x) * Mathf.Rad2Deg -90;

        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;


        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.spawnerTag = this.gameObject.tag;

        float bulletSpeed = bulletComponent.Speed;
        bullet.GetComponent<Rigidbody>().velocity =
            bulletSpeed * direction;
    }
}

