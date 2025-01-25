using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject basicBulletPrefab;
    private CombatInput combatInput;
    private Vector3 aimedPosition;

    AcidityController acidityController;

    private void Start()
    {
        combatInput = GetComponent<CombatInput>();
        acidityController = GetComponent<AcidityController>();
    }

    private void Update()
    {
        // aimedPosition = GetComponent<PlayerAim>().LookDirection;
    }

    private void FixedUpdate()
    {
        // if (combatInput.BasicAttack)
        // {
        //     ShootBullet();
        //     combatInput.BasicAttack = false;
        // }
    }

    public void ShootBullet()
    {
        if (combatInput.isShooting)
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("Bullet prefab is not assigned in the inspector.");
                return;
            }

            Vector3 worldPosition = transform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            float angle =
                Mathf.Atan2(
                    Input.mousePosition.y - screenPosition.y,
                    screenPosition.x - Input.mousePosition.x
                ) * Mathf.Rad2Deg
                - 90;

            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            GameObject bullet;

            if (acidityController.AcidityLevel > 0)
            {
                bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
            else
            {
                bullet = Instantiate(
                    this.basicBulletPrefab,
                    transform.position,
                    transform.rotation
                );
            }

            // GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.spawnerTag = this.gameObject.tag;
            bulletComponent.AcidDamage = (int)acidityController.AcidityLevel;

            float bulletSpeed = bulletComponent.Speed;
            bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * direction;
        }
    }
}
