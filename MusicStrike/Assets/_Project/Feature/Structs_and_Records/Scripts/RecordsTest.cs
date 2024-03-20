using UnityEngine;

namespace Structs_and_Records_Course
{
    public class RecordsTest : MonoBehaviour
    {
        public IntRecord intRecord1;
        public IntRecord intRecord2;

        public IntClass intClass1;
        public IntClass intClass2;

        [ContextMenu(nameof(CheckEquality_Record))]
        private void CheckEquality_Record()
        {
            Debug.Log($"{nameof(intRecord1)} and {nameof(intRecord2)} are equal: {intRecord1 == intRecord2}");
        }

        [ContextMenu(nameof(CheckEquality_Class))]
        private void CheckEquality_Class()
        {
            Debug.Log($"{nameof(intClass1)} and {nameof(intClass2)} are equal: {intClass1 == intClass2}");
        }
    }
}