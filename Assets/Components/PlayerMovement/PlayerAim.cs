using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private MouseCursor mouseCursor;
    public Vector3 LookDirection { get; set; }
    public LayerMask layerMask;
    private void Start()
    {
        mouseCursor = GameObject.Find("GameManager").GetComponent<MouseCursor>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, mouseCursor.Position - transform.position); // Hitung arah ray
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask)) // Tambahkan layerMask di sini
        {
            LookDirection = hit.point;
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}
