using CSE.WorkerService.Jobs.HealthJob;

var builder = Host.CreateApplicationBuilder(args);

#region Register worker service jobs

builder.Services.AddHostedService<HealthJob>();

#endregion

var host = builder.Build();

host.Run();
