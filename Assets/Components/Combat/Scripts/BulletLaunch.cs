using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private CombatInput combatInput;
    private Vector3 aimedPosition;
    private void Start()
    {
        combatInput = GetComponent<CombatInput>();
    }
    private void Update()
    {
        aimedPosition = GetComponent<PlayerAim>().LookDirection;

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

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        float bulletSpeed = bullet.GetComponent<Bullet>().Speed;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * (aimedPosition - transform.position).normalized;
    }

}