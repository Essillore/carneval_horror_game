using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaController : MonoBehaviour
{
    public Image imageToControl; // Reference to the UI Image you want to control.
    public float minTemperature = -1f; // Minimum temperature for maximum alpha (e.g., -1).
    public float maxTemperature = 38f; // Maximum temperature for minimum alpha (e.g., 38).
    public float currentTemperature; // The current temperature value.
    public float alphaSpeed = 2f; // Speed of the alpha transition.

    private Color targetColor; // The target color with the desired alpha.

    void Start()
    {
        targetColor = imageToControl.color; // Store the initial color.
    }

    void Update()
    {
        // Ensure that the currentTemperature is clamped within the specified range.
        currentTemperature = Mathf.Clamp(currentTemperature, minTemperature, maxTemperature);

        // Calculate the alpha value based on currentTemperature.
        float alpha = Mathf.InverseLerp(maxTemperature, minTemperature, currentTemperature);

        // Smoothly interpolate the alpha value.
        float newAlpha = Mathf.Lerp(imageToControl.color.a, alpha, Time.deltaTime * alphaSpeed);

        // Update the color with the new alpha value.
        targetColor.a = newAlpha;
        imageToControl.color = targetColor;
    }
}