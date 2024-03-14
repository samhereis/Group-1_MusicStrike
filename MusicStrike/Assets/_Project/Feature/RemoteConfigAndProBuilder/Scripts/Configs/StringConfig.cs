using System.Threading.Tasks;
using UnityEngine;

namespace RemoteConfingCourse
{
    [CreateAssetMenu(fileName = nameof(StringConfig), menuName = "SO/" + nameof(StringConfig))]
    public class StringConfig : ConfigBase<string>
    {
        public async override Task<string> FetchValue()
        {
            if (_configContainer == null)
            {
                SetValue(_defaultValue);
            }
            else
            {
                SetValue(await _configContainer.GetString(_key, _defaultValue, _numberOfTries));
            }

            return _value;
        }
    }
}