using System;

namespace Structs_and_Records_Course
{
    [Serializable]
    public record IntRecord
    {
        public int value;

        public IntRecord(int value)
        {
            this.value = value;
        }
    }
}
