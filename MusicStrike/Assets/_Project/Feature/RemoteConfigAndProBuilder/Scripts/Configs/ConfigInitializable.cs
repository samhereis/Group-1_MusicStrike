using UnityEngine;

namespace RemoteConfingCourse
{
    public abstract class ConfigInitializable : ScriptableObject
    {
        public abstract void Initialize(IConfigContainer configContainer);
    }
}