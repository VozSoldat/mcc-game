using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Vector3 position;
    public Vector3 Position { get => position; private set => position = value; }
    public LayerMask layerMask;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
        {
            Position = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
    }
}