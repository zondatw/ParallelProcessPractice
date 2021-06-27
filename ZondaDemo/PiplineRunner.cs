using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
}
