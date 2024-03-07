using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicData : MonoBehaviour
{
    public AudioSource audioSource;
    public float[] spectrum = new float[64];
    public FFTWindow fftWindow;

    public float multiplier = 1;
    public int frequencyRange = 45;
    public float changeSpeed = 1;

    public Transform[] reactables;

    private float[] _currentSpectrum;

    public SpectrumFrequenctData bass;
    public SpectrumFrequenctData mid;
    public SpectrumFrequenctData high;

    private void Awake()
    {
        if (audioSource == null) { audioSource = GetComponent<AudioSource>(); }
        _currentSpectrum = new float[frequencyRange];
        foreach (Transform t in reactables[frequencyRange..reactables.Length])
        {
            t.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, fftWindow);
        _currentSpectrum = spectrum[0..frequencyRange];

        for (int i = 0; i < frequencyRange; i++)
        {
            if (i > _currentSpectrum.Length - 1) break;

            Transform reactable = reactables[i];
            Vector3 scale = reactable.localScale;
            scale.y = GetFrequency(i);

            reactable.localScale = Vector3.Lerp(reactable.localScale, scale, changeSpeed * Time.deltaTime);
        }

        bass.Update(_currentSpectrum);
        mid.Update(_currentSpectrum);
        high.Update(_currentSpectrum);
    }

    private float GetFrequency(int index)
    {
        return (_currentSpectrum[index] * (1 + index)) * multiplier;
    }

    [Serializable]
    public class SpectrumFrequenctData
    {
        public float value;

        public Vector2Int range;
        public float multiplier;

        public Transform scaleObject;
        public float changeSpeed = 1;

        public void Update(float[] spectrum)
        {
            if (spectrum.Length < range.y) { return; }

            value = spectrum[range.x..range.y].Average() * multiplier;

            Vector3 scale = scaleObject.localScale;
            scale.y = value;

            scaleObject.localScale = Vector3.Lerp(scaleObject.localScale, scale, changeSpeed * Time.deltaTime);
        }
    }
}