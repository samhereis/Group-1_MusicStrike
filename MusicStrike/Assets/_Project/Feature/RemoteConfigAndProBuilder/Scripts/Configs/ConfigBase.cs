using System;
using System.Threading.Tasks;
using UnityEngine;

namespace RemoteConfingCourse
{
    public abstract class ConfigBase<T> : ConfigInitializable
    {
        public Action<T> onValueChanged;

        [SerializeField] protected T _value;

        [Header("Settings")]
        [SerializeField] protected T _defaultValue;
        [SerializeField] protected string _key = "key";
        [SerializeField] protected int _numberOfTries = 10;

        protected IConfigContainer _configContainer;

        public async override void Initialize(IConfigContainer configContainer)
        {
            _configContainer = configContainer;
            SetValue(await FetchValue());
        }

        public abstract Task<T> FetchValue();

        public virtual void SetValue(T newValue)
        {
            _value = newValue;
            onValueChanged?.Invoke(_value);
        }
    }
}