using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasVisibilityController : MonoBehaviour
{
    public Image image; // Reference to the Image component you want to control
    public bool isVisible = false; // Control the visibility of the image

    public void ToggleImageVisibility()
    {
        image.enabled = isVisible;
    }
}