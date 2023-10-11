using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class WaveColorExampleScript : MonoBehaviour
{
    // Reference to the URP Volume component on your camera
    public PostProcessVolume postProcessVolume;
    public MeshRenderer cubeRenderer;
    private ColorGrading colorGrading;
    private AnimationCurve waveCurve;
    private float waveSpeed = 0.02f;
    private float waveAmplitude = 1.5f;

    // Audio variables
    public AudioSource audioSource;
    public float hueShiftMultiplier = 360f; // Adjust this value to control the range of hue shift
    public float audioAmplitudeScale = 1.0f;

    private Material cubeMaterial;
    private Color originalEmissionColor;

    private void Start()
    {
        cubeMaterial = cubeRenderer.material;
        originalEmissionColor = cubeMaterial.GetColor("_EmissionColor");

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
        waveCurve.AddKey(new Keyframe(0.0f, 0.0f));
        waveCurve.AddKey(new Keyframe(0.141f, 0.710f));         // Transition from black to blue
        waveCurve.AddKey(new Keyframe(0.355f, 0.240f));          // Blue
        waveCurve.AddKey(new Keyframe(0.609f, 0.683f));         // Transition from blue to black
        waveCurve.AddKey(new Keyframe(0.801f, 0.240f));          // End with black

    }

    // Coroutine to move the wave over time
    private IEnumerator MoveWave()
    {
        float time = 0.1f;

        while (true)
        {
            // Update the curve's keyframes to create the moving wave
            for (int i = 0; i < waveCurve.length; i++)
            {
                Keyframe key = waveCurve[i];
                key.value = Mathf.Sin((key.time + time) * waveSpeed) * waveAmplitude;
                waveCurve.MoveKey(i, key);
            }

            time += Time.deltaTime;

            // Get audio spectrum data
            float[] spectrumData = new float[256]; // You can adjust the size as needed
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

            // Calculate the average amplitude from the spectrum data
            float averageAmplitude = 0f;
            for (int i = 0; i < spectrumData.Length; i++)
            {
                averageAmplitude += spectrumData[i];
            }
            averageAmplitude /= spectrumData.Length;

            // Calculate hue shift based on audio amplitude
            float hueShift = averageAmplitude * audioAmplitudeScale * hueShiftMultiplier;

            // Apply the hue shift to the Color Grading effect
            colorGrading.hueShift.value = hueShift;

            // Apply the color change to the object's emission
            Color newEmissionColor = Color.HSVToRGB(hueShift / 360f, 1f, 1f);
            cubeMaterial.SetColor("_EmissionColor", newEmissionColor * averageAmplitude); // Adjust the multiplier for intensity


            yield return null;
        }
    }

    private void OnDestroy()
    {
        // Restore the original emission color when the script is destroyed
       // cubeMaterial.SetColor("_EmissionColor", originalEmissionColor);
    }
}