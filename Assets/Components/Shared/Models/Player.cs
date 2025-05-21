using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IEntity
{
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] public int maxHealth = 100;
    AcidityController acidityController;

    public UnityEvent<int> OnHealthChange = new();
    public UnityEvent OnDeath = new();

    private bool isDead = false;
    private int health;

    public int Health
    {
        get => health;
        set
        {
            if (isDead)
                return;

            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChange.Invoke(health);


            if (health <= 0)
                Die();
        }
    }

    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }

    void Start()
    {
        health = maxHealth;
        acidityController = GetComponent<AcidityController>();
        acidityController.AcidityLevel = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        acidityController.AcidityLevel = -acidityController.AcidityLevel;
    }

    private void Die()
    {
        isDead = true;
        OnDeath.Invoke();
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child != transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        enabled = false;
    }
}

