// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AcidityController : MonoBehaviour
{
    public UnityEvent<float> OnAcidityChange = new UnityEvent<float>();

    [SerializeField]
    float acidityLevel = 0;
    public float AcidityLevel
    {
        get => this.acidityLevel;
        set
        {
            this.acidityLevel = Mathf.Clamp(value, -7, 7);
            this.OnAcidityChange.Invoke(this.acidityLevel);
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        // this.OnAcidityChange.Invoke(this.acidityLevel);
    }
}
