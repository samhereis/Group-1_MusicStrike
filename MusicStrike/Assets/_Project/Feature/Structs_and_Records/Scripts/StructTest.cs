using System;
using UnityEngine;

namespace Structs_and_Records_Course
{
    public class StructTest : MonoBehaviour
    {
        public IntClass intClass;

        public IntStruct intStruct1;
        public IntStruct intStruct2;

        [ContextMenu(nameof(Test))]
        private void Test()
        {
            AddValue_Class(intClass);

            AddValue_Struct(intStruct1);
            AddValue_Struct_Ref(ref intStruct2);
        }

        private void AddValue_Class(IntClass intClass)
        {
            intClass.value++;
        }

        private void AddValue_Struct(IntStruct intRecord)
        {
            intRecord.value++;
        }

        private void AddValue_Struct_Ref(ref IntStruct intRecord)
        {
            intRecord.value++;
        }
    }
}