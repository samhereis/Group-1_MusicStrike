using UnityEngine;

namespace SO.Music
{
    public class MusicVisualizationData : MonoBehaviour
    {
        [field: SerializeField] public float value { get; private set; }
        [field: SerializeField] public Vector2Int range { get; private set; }
        [field: SerializeField] public float _multiplier { get; private set; } = 1;

        public void SetValue(float newValue)
        {
            value = newValue * _multiplier;
        }
    }
}