using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ParallelProcessPractice.Core;

namespace ZondaDemo
{
    public class BasicLoopRunner: TaskRunnerBase
    {
        public override void Run(IEnumerable<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                task.DoStepN(1);
                task.DoStepN(2);
                task.DoStepN(3);
            }
        }
    }
    public class BasicLoopStepLevelRunner : TaskRunnerBase
    {
        public override void Run(IEnumerable<MyTask> tasks)
        {
            var taskList = tasks.ToArray();
            for (int step = 1; step <= 3; step++)
            {
                foreach (var task in taskList)
                {
                    task.DoStepN(1);
                }
                foreach (var task in taskList)
                {
                    task.DoStepN(2);
                }
                foreach (var task in taskList)
                {
                    task.DoStepN(3);
                }
            }
        }
    }
}
