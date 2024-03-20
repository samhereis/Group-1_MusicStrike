using System;

namespace Structs_and_Records_Course
{
    [Serializable]
    public struct IntStruct
    {
        public int value;

        public IntStruct(int value)
        {
            this.value = value;
        }
    }
}
