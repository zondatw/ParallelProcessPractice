using ParallelProcessPractice.Core;
using System;

namespace ZondaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskRunnerBase run =
                // new BasicLoopRunner();
                // new BasicLoopStepLevelRunner();
                // new PipelineRunner();
                // new PipelineAsyncRunner();
                // new PipelineQueueRunner();
                new PipelineTreadQueueRunner();
            run.ExecuteTasks(100);
        }
    }
}
