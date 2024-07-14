// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using LoggingPracticeBenchmark;

var summary = BenchmarkRunner.Run(typeof(Benchmarkie).Assembly);