using TMPro;
using UnityEngine;

namespace RemoteConfingCourse
{
    public class RemoteConfigTest : MonoBehaviour
    {
        public StringConfig stringConfig;
        public TextMeshProUGUI testText;

        private async void OnEnable()
        {
            SetText(await stringConfig.FetchValue());
            stringConfig.onValueChanged += SetText;
        }

        private void OnDisable()
        {
            stringConfig.onValueChanged -= SetText;
        }

        private void SetText(string value)
        {
            testText.text = value;
        }
    }
}