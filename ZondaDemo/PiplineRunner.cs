using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ParallelProcessPractice.Core;

namespace ZondaDemo
{
    public class PipelineRunner : TaskRunnerBase
    {
        public override void Run(IEnumerable<MyTask> tasks)
        {
            foreach (var task in Step3(Step2(Step1(tasks)))) ;
        }

        private IEnumerable<MyTask> Step1(IEnumerable<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                task.DoStepN(1);
                yield return task;
            }

        }

        private IEnumerable<MyTask> Step2(IEnumerable<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                task.DoStepN(2);
                yield return task;
            }

        }

        private IEnumerable<MyTask> Step3(IEnumerable<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                task.DoStepN(3);
                yield return task;
            }

        }
    }
    public class PipelineAsyncRunner : TaskRunnerBase
    {
        public override void Run(IEnumerable<MyTask> tasks)
        {
            foreach (var task in Step3(Step2(Step1(tasks)))) ;
        }

        private IEnumerable<MyTask> Step1(IEnumerable<MyTask> tasks)
        {
            Task<MyTask> previous_result = null;
            foreach (var task in tasks)
            {
                if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
                previous_result = Task.Run<MyTask>(() => { task.DoStepN(1); return task; });
            }
            if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
        }

        private IEnumerable<MyTask> Step2(IEnumerable<MyTask> tasks)
        {
            Task<MyTask> previous_result = null;
            foreach (var task in tasks)
            {
                if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
                previous_result = Task.Run<MyTask>(() => { task.DoStepN(2); return task; });
            }
            if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
        }

        private IEnumerable<MyTask> Step3(IEnumerable<MyTask> tasks)
        {
            Task<MyTask> previous_result = null;
            foreach (var task in tasks)
            {
                if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
                previous_result = Task.Run<MyTask>(() => { task.DoStepN(3); return task; });
            }
            if (previous_result != null) yield return previous_result.GetAwaiter().GetResult();
        }
    }
    public class PipelineQueueRunner : TaskRunnerBase
    {
        const int BLOCKING_COLLECTION_CAPACITY = 10;
        public override void Run(IEnumerable<MyTask> tasks)
        {
            foreach (var task in Step3(Step2(Step1(tasks)))) ;
        }

        private IEnumerable<MyTask> Step1(IEnumerable<MyTask> tasks)
        {
            BlockingCollection<MyTask> result = new BlockingCollection<MyTask>(BLOCKING_COLLECTION_CAPACITY);
            Task.Run(() =>
            {
                foreach (var task in tasks)
                {
                    task.DoStepN(1);
                    result.Add(task);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private IEnumerable<MyTask> Step2(IEnumerable<MyTask> tasks)
        {
            BlockingCollection<MyTask> result = new BlockingCollection<MyTask>(BLOCKING_COLLECTION_CAPACITY);
            Task.Run(() =>
            {
                foreach (var task in tasks)
                {
                    task.DoStepN(2);
                    result.Add(task);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }

        private IEnumerable<MyTask> Step3(IEnumerable<MyTask> tasks)
        {
            BlockingCollection<MyTask> result = new BlockingCollection<MyTask>(BLOCKING_COLLECTION_CAPACITY);
            Task.Run(() =>
            {
                foreach (var task in tasks)
                {
                    task.DoStepN(3);
                    result.Add(task);
                }
                result.CompleteAdding();
            });
            return result.GetConsumingEnumerable();
        }
    }
    public class PipelineTreadQueueRunner : TaskRunnerBase
    {
        private BlockingCollection<MyTask>[] queues =
        {
            new BlockingCollection<MyTask>(), // task for step 1
            new BlockingCollection<MyTask>(), // task for step 2
            new BlockingCollection<MyTask>(), // task for step 2
        };

        public override void Run(IEnumerable<MyTask> tasks)
        {
            List<Thread> threads = new List<Thread>();
            Thread thread = null;
            int[] TASK_STEPS_CONCURRENT_LIMIT =
            {
                0,  // STEP 0, useless
                5,
                3,
                3
            };

            // Create multithreading, how many thread number by TASK_STEPS_CONCURRENT_LIMIT
            for (int threadCount = 0; threadCount < TASK_STEPS_CONCURRENT_LIMIT[1]; threadCount++)
            {
                threads.Add(thread = new Thread(this.Step1));
                thread.Start();
            }
            for (int threadCount = 0; threadCount < TASK_STEPS_CONCURRENT_LIMIT[2]; threadCount++)
            {
                threads.Add(thread = new Thread(this.Step2));
                thread.Start();
            }
            for (int threadCount = 0; threadCount < TASK_STEPS_CONCURRENT_LIMIT[3]; threadCount++)
            {
                threads.Add(thread = new Thread(this.Step3));
                thread.Start();
            }

            // Add task to queue 0 that for step 1
            foreach (var task in tasks)
            {
                this.queues[0].Add(task);
            }

            // Check all step and thread are finished
            for (int step = 1; step <= 3; step++)
            {
                this.queues[step-1].CompleteAdding();
                for (int i = 0; i < TASK_STEPS_CONCURRENT_LIMIT[step]; i++)
                {
                    threads[0].Join();
                    threads.RemoveAt(0);
                }
            }
        }

        private void Step1()
        {
            int step = 1;
            foreach (var task in this.queues[step - 1].GetConsumingEnumerable())
            {
                task.DoStepN(step);
                this.queues[step].Add(task);
            }
        }

        private void Step2()
        {
            int step = 2;
            foreach (var task in this.queues[step - 1].GetConsumingEnumerable())
            {
                task.DoStepN(step);
                this.queues[step].Add(task);
            }
        }

        private void Step3()
        {
            int step = 3;
            foreach (var task in this.queues[step - 1].GetConsumingEnumerable())
            {
                task.DoStepN(step);
            }
        }
    }
}
