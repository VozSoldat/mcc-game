// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SpriteFaceCamera : MonoBehaviour
{
    void Start() { }

    void Update()
    {
        var mainCameraEuler = Camera.main.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(-mainCameraEuler.x, mainCameraEuler.y+180, 0);
    }
}
