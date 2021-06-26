using System;
using System.Collections.Generic;
using System.Text;
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
}
