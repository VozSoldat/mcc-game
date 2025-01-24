using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRange : MonoBehaviour
{
    AIShooter parent;
    // Start is called before the first frame update
    void Start()
    {
        this.parent = GetComponentInParent<AIShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        this.parent.OnEnterShootRange(other);
    }

    private void OnTriggerExit(Collider other)
    {
        this.parent.OnExitShootRange(other);
    }
}
