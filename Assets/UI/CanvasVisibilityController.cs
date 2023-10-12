using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasVisibilityController : MonoBehaviour
{
    public List<CanvasVisibilityController> canvasControllers = new List<CanvasVisibilityController>();
    public Image image;

    public void ToggleImageVisibility()
    {
        foreach (CanvasVisibilityController controller in canvasControllers)
        {
            Image image = controller.image;
            image.enabled = !image.enabled; // Toggle visibility
        }
    }
}