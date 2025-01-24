using UnityEngine;

public class TestRay : MonoBehaviour{
    private void Update() {
        Vector3 aimedPosition = GameObject.Find("Player").GetComponent<PlayerAim>().LookDirection;
        transform.position = aimedPosition;
    }
}