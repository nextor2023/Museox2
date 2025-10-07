using UnityEngine;
using UnityEngine.UI;

public class SystemDetection : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Transform rayOrigin;
    public float distance = 5f;
    public float offset = 0f;
    public LayerMask interActiveLayer;

    [Header("UI Settings")]
    public Image targetImage; // Imagen HUD que cambia según el objeto

    private MyObjectMuseum lastTarget;

    private void Update()
    {
        Vector3 origin = rayOrigin.position + rayOrigin.forward * offset;
        Vector3 direction = rayOrigin.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance, interActiveLayer))
        {
            MyObjectMuseum target = hit.collider.GetComponent<MyObjectMuseum>();

            if (target != null)
            {
                if (lastTarget != target)
                {
                    if (lastTarget != null)
                        lastTarget.DesactiveMyCanvas();

                    target.ActiveMyCanvas();
                    lastTarget = target;

                    // Cambiar HUD
                    if (targetImage != null && target.objectSprite != null)
                    {
                        targetImage.sprite = target.objectSprite;
                        targetImage.enabled = true;
                    }
                }
            }
        }
        else
        {
            if (lastTarget != null)
            {
                lastTarget.DesactiveMyCanvas();
                lastTarget = null;

                if (targetImage != null)
                    targetImage.enabled = false;
            }
        }

        Debug.DrawRay(origin, direction * distance, Color.red);
    }
}
