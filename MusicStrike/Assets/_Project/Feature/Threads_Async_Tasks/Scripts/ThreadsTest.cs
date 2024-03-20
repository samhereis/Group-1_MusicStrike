using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ThreadsCourse
{
    public class ThreadsTest : MonoBehaviour
    {
        public int[] numbers;

        [ContextMenu(nameof(Clear_Thread))]
        private void Clear_Thread()
        {
            new Thread(async () =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = 0;
                    await Task.Yield();
                }
            }).Start();
        }

        [ContextMenu(nameof(Clear_Task))]
        private async void Clear_Task()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = 0;
                    await Task.Yield();
                }
            });
        }

        [ContextMenu(nameof(MultiTasking))]
        private async void MultiTasking()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
                await Task.Yield();
            }
            Debug.Log("Finished");
        }

        [ContextMenu(nameof(MultiThreading_Thread))]
        private void MultiThreading_Thread()
        {
            Thread myThread = new Thread(async () =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = i + 1;
                    await Task.Yield();
                }
                Debug.Log("Finished");
            });
            myThread.Start();
        }

        [ContextMenu(nameof(MultiThreading_Task))]
        private async void MultiThreading_Task()
        {
            Task myTask = Task.Run((async () =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = i + 1;
                    await Task.Yield();
                }
            }));

            await myTask;
            Debug.Log("Finished");
        }
    }
}