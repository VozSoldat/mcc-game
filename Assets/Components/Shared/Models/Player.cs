using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IEntity
{
    [SerializeField]
    private float movementSpeed = 100;

    [SerializeField]
    private int health = 100;
    public int maxHealth;

    AcidityController acidityController;

    public float MovementSpeed
    {
        get => movementSpeed;
        set => movementSpeed = value;
    }

    public int Health
    {
        get => health;
        set
        {
            health = Math.Clamp(value, 0, 100);
            this.OnHealthChange.Invoke(this.Health);
        }
    }

    public UnityEvent<int> OnHealthChange = new UnityEvent<int>();

    void Start()
    {
        maxHealth = health;
        acidityController = GetComponent<AcidityController>();
        acidityController.AcidityLevel = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            acidityController.AcidityLevel = -acidityController.AcidityLevel;
        // this.OnHealthChange.Invoke(this.Health);
    }
}
