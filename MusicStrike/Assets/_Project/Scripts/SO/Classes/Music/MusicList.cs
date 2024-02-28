using System.Collections.Generic;
using UnityEngine;

namespace SO.Music
{
    public class MusicList : MonoBehaviour
    {
        [field: SerializeField] public List<AudioClip> musicList = new List<AudioClip>();
    }
}