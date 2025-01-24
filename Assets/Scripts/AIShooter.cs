using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooter : Entity
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnEnterShootRange(Collider other)
    {
        Debug.Log("OnEnterShootRange");
    }

    public virtual void OnExitShootRange(Collider other)
    {
        Debug.Log("OnExitShootRange");
    }
}