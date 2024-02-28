using SO.Music;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class MusicDataProcessor : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private MusicList _musicList;
        [SerializeField] private MusicVisualizationData[] _musicVisualizationDatas;

        private float[] _spectrumWidth = new float[64];

        public void Update()
        {
            _audioSource.GetSpectrumData(_spectrumWidth, 0, FFTWindow.Rectangular);

            foreach (var musicVisualizationData in _musicVisualizationDatas)
            {
                float value = _spectrumWidth[musicVisualizationData.range.x..musicVisualizationData.range.y].Average();
                musicVisualizationData.SetValue(value);
            }
        }
    }
}