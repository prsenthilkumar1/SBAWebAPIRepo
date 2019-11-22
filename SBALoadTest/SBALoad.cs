using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using NBench.Util;
using SBAWebAPI.Controllers;
using System.Web.Http;

namespace SBALoadTest
{
    public class SBALoad
    {
        //private Counter _counter;

        //[PerfSetup]
        //public void SetUp(BenchmarkContext context)
        //{
        //    _counter = context.GetCounter("TestCounter");
        //}

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput,TestMode = TestMode.Test, RunTimeMilliseconds = 600000, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000000)]
        public void Benchmark_Performance_ElaspedTime()
        {
            UserAPIController userAPI = new UserAPIController();

            for (int i = 0; i < 500; i++)
            {
                userAPI.Get();
            }
        }
    }
}
