// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SpriteStill : MonoBehaviour
{
    Vector3 initialRotation;
    Transform parent;

    void Start()
    {
        this.initialRotation = this.transform.eulerAngles;
        this.parent = this.transform.parent;
    }

    void Update()
    {
        this.transform.eulerAngles = this.initialRotation;
        this.transform.eulerAngles -= Vector3.up * this.parent.eulerAngles.y;
    }
}
