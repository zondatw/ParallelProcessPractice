using ParallelProcessPractice.Core;
using System;

namespace ZondaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskRunnerBase run = new BasicLoopRunner();
            run.ExecuteTasks(10);
        }
    }
}
