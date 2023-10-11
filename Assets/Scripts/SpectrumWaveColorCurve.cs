using UnityEngine;
using System.Collections;
//using UnityEngine.Rendering.PostProcessing;
/*
public class SpectrumWaveColorCurve : MonoBehaviour
{
    // Reference to the URP Volume component on your camera
 //   public PostProcessVolume postProcessVolume;
    public MeshRenderer cubeRenderer;
   // private ColorGrading colorGrading;
    private AnimationCurve waveCurve;
    private float waveSpeed = 0.02f;
    private float waveAmplitude = 0.9f;

    // Audio variables
    public AudioSource audioSource;
    public float hueShiftMultiplier = 360f; // Adjust this value to control the range of hue shift
    public float audioAmplitudeScale = 1.0f;

     private void Start()
    {
         Check if the postProcessingVolume is assigned
        if (postProcessVolume == null)
        {
            Debug.LogError("Post Processing Volume is not assigned!");
            return;
        }

         Try to get the ColorCurves effect from the post-processing profile
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
        waveCurve.AddKey(new Keyframe(0.801f, 0.240f));
    }

    // Coroutine to move the wave over time
    private IEnumerator MoveWave()
    {
        float time = 0.0f;

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

            for (int i = 0; i < spectrumData.Length; i++)
            {
                float tmp = spectrumData[i] * 160;
                if (tmp >= 3f)
                {
                    //gameObject.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                    Debug.Log(spectrumData[i]);
                }

                // Calculate the average amplitude from the spectrum data
                float averageAmplitude = 0f;
                for (int j = 0; j < spectrumData.Length; j++)
                {
                    averageAmplitude += spectrumData[i];
                }
                averageAmplitude /= spectrumData.Length;

                // Calculate hue shift based on audio amplitude
                float hueShift = averageAmplitude * audioAmplitudeScale * hueShiftMultiplier;

                // Apply the hue shift to the Color Grading effect
                colorGrading.hueShift.value = hueShift;

                yield return null;

            }

        }
    }
}
    */