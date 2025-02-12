using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL
{
    public class MethodsOfTPL
    {
        // using Task.WhenAll()
        // Waits for all tasks to complete asynchronously.
        // Returns a Task that completes when all the provided tasks are finished.
        // It does not block the current thread; it follows the async-await pattern.
        // If any task fails, the remaining tasks still continue execution.
        public async Task RunTasksAsync()
        {
            Task<int> task1 = Task.Run(() => { Thread.Sleep(1000); return 10; });
            Task<int> task2 = Task.Run(() => { Thread.Sleep(2000); return 20; });

            int[] results = await Task.WhenAll(task1, task2);
            Console.WriteLine($"Sum: {results.Sum()}"); // Output after 2 sec: Sum: 30
        }
        // using Task.WhenAny();
        // Waits for only one of the provided tasks to complete and returns that task.
        // Other tasks continue running in the background.
        //  Returns the completed task itself (not the result).
        public async Task RunTasks()
        {
            Task<int> task1 = Task.Run(() => { Thread.Sleep(1000); return 10; });
            Task<int> task2 = Task.Run(() => { Thread.Sleep(2000); return 20; });

            Task<int> firstCompleted = await Task.WhenAny(task1, task2);
            Console.WriteLine($"First completed task result: {firstCompleted.Result}"); // Output after 1 sec: First completed task result: 10
        }
        // using Task.WaitAll();
        // Blocks the current thread until all tasks complete.
        // Unlike Task.WhenAll(), it is synchronous and does not return a Task.
        // If any task throws an exception, execution is halted immediately.
        public void RunTasksSync()
        {
            Task task1 = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("Task 1 completed"); });
            Task task2 = Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Task 2 completed"); });

            Task.WaitAll(task1, task2);
            Console.WriteLine("All tasks completed");
        }
    }
}