// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using NBomber.Contracts;
using NBomber.CSharp;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");
//var summary = BenchmarkRunner.Run<Md5VsSha256>();


using var httpClient = new HttpClient();
// first, you need to create a step
var step = Step.Create("step", async context =>
{
    // you can define and execute any logic here,
    // for example: send http request, SQL query etc
    // NBomber will measure how much time it takes to execute your logic
    var ressource = new List<int>() { 1,5};
    var response = await httpClient.PostAsJsonAsync("https://localhost:7091/api/movie/GetAllPaginated", ressource);
    await Task.Delay(TimeSpan.FromSeconds(1));
    return response.IsSuccessStatusCode
                        ? Response.Ok()
                        : Response.Fail();
});

// second, we add our step to the scenario
var scenario = ScenarioBuilder.CreateScenario("hello_world", step)
    .WithWarmUpDuration(TimeSpan.FromSeconds(10))
    .WithLoadSimulations(Simulation.RampConstant(10, TimeSpan.FromSeconds(10)));

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();
