using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOpacityController : MonoBehaviour
{
    public Material material;
    [Range(0, 255)]
    public float materialAlpha;
    public float alphaValue;
    public float alphaSpeed = 2f; // Speed of the alpha transition.

    private Color targetColor; // The target color with the desired alpha.

    void Start()
    {
        targetColor = material.color; // Store the initial color.
    }

    void Update()
    {
        alphaValue = materialAlpha / 255;

        // Calculate the alpha value based on ???, atm. time.
        float alpha = Mathf.InverseLerp(Time.time, 0f, 0.1f);

        // Smoothly interpolate the alpha value.
        float newAlpha = Mathf.Lerp(material.color.a, alphaValue, Time.deltaTime * alphaSpeed);

        // Update the color with the new alpha value.
        targetColor.a = newAlpha;
        material.color = targetColor;
    }
}