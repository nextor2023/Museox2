using UnityEngine;
using UnityEngine.UI;

public class MyObjectMuseum : MonoBehaviour
{
    [Header("Canvas del objeto")]
    public Canvas MyCanvas; 

    [Header("Imagen asociada (opcional)")]
    public Sprite objectSprite; 

 
    public void ActiveMyCanvas()
    {
        if (MyCanvas != null)
            MyCanvas.enabled = true;
    }

    // Desactivar Canvas
    public void DesactiveMyCanvas()
    {
        if (MyCanvas != null)
            MyCanvas.enabled = false;
    }
}
