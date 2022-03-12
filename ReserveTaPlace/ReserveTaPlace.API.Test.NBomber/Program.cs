using NBomber.Contracts;
using NBomber.CSharp;

using var httpClient = new HttpClient();

var step = Step.Create("fetchUsers", async context =>
{
    var reponse = await httpClient.GetAsync("https://localhost:7091/api/Theater");

    return reponse.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
});

var scenario = ScenarioBuilder
    .CreateScenario("UsersAll", step)
    .WithWarmUpDuration(TimeSpan.FromSeconds(10))
    .WithLoadSimulations(Simulation.RampConstant(100, TimeSpan.FromSeconds(50)));

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();
