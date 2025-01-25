using UnityEngine;

public class ToggleMeshRenderer : MonoBehaviour
{
    // Toggle the MeshRenderer for this object and all its children
    public void Toggle()
    {
        ToggleMeshRenderers(transform, !GetComponent<MeshRenderer>().enabled);
    }

    public void Activate()
    {
        ToggleMeshRenderers(transform, true);
    }

    public void Deactivate()
    {
        ToggleMeshRenderers(transform, false);
    }

    // Recursive method to toggle MeshRenderers
    private void ToggleMeshRenderers(Transform parent, bool enabled)
    {
        // Toggle the MeshRenderer on the current object
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = enabled;
        }

        // Recursively toggle MeshRenderers on all children
        foreach (Transform child in parent)
        {
            ToggleMeshRenderers(child, enabled);
        }
    }
}
