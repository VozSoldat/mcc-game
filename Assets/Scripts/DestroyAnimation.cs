using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
