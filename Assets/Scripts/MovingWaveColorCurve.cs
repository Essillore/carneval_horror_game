 using UnityEngine;
using System.Collections;
/* using UnityEngine.Rendering.PostProcessing;

public class MovingWaveColorCurve : MonoBehaviour
{
    // Reference to the URP Volume component on your camera
    public PostProcessVolume postProcessVolume;
    public MeshRenderer cubeRenderer;
    private ColorGrading colorGrading;
    //movingWaveCurve;
    private AnimationCurve waveCurve;
    private float waveSpeed = 0.5f;
    private float waveAmplitude = 1.5f;

    private void Start()
    {
        // Check if the postProcessingVolume is assigned
        if (postProcessVolume == null)
        {
            Debug.LogError("Post Processing Volume is not assigned!");
            return;
        }

        // Try to get the ColorCurves effect from the post-processing profile
        if (postProcessVolume.profile.TryGetSettings(out ColorGrading cg))
        {
            colorGrading = cg;
        }
        else
        {
            Debug.LogError("Color Curves effect not found in the post-processing profile.");
            return;
        }

        // Initialize the wave curve
        InitializeWaveCurve();

        // Start the wave movement
        StartCoroutine(MoveWave());
    }

    // Initialize the wave curve
    private void InitializeWaveCurve()
    {
        waveCurve = new AnimationCurve();
        // waveCurve.AddKey(new Keyframe(0.0f, 0.0f));
        // waveCurve.AddKey(new Keyframe(1.0f, 0.0f));

        // Adjust the keyframes to emphasize blue values
        waveCurve.AddKey(new Keyframe(0.0f, 0.0f));
        waveCurve.AddKey(new Keyframe(0.141f, 0.710f));         // Transition from black to blue
        waveCurve.AddKey(new Keyframe(0.355f, 0.240f));          // Blue
        waveCurve.AddKey(new Keyframe(0.609f, 0.683f));         // Transition from blue to black
        waveCurve.AddKey(new Keyframe(0.801f, 0.240f));          // End with black

    }

    // Coroutine to move the wave over time
    private IEnumerator MoveWave()
    {
        float time = 0.0f;
        Color originalColor = Color.white;  // Assuming your wave starts as white

        while (true)
        {
            // Update the curve's keyframes to create the moving wave
            for (int i = 0; i < waveCurve.length; i++)
            {
                Keyframe key = waveCurve[i];
                key.value = Mathf.Sin((key.time + time) * waveSpeed) * waveAmplitude;
                waveCurve.MoveKey(i, key);

                // Calculate the hue value based on the key's value
                float hue = Mathf.Lerp(240f, 0f, key.value);  // Blue to Red (adjust the values as needed)

                // Convert hue to RGB color
                Color newColor = Color.HSVToRGB(hue / 360f, 1f, 1f);

                // Apply the new color to your wave (assuming you have a Renderer)
                cubeRenderer.material.color = newColor;  // Replace "yourRenderer" with your actual wave's renderer
            }

            time += Time.deltaTime;
            yield return null;
                // Assign the updated curve to the blue channel
          //      colorGrading.hueShift.value = waveCurve.Evaluate;


            }
        }
    }
*/
