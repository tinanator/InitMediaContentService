using InitMediaContentService.Application.Extensions;
using InitMediaContentService.Domain.Extensions;
using InitMediaContentService.Infrastructure.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using InitMediaContentService.Application.Exceptions;
using System.Net;
using System.Runtime.InteropServices;
using System.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddMediaContext(builder.Configuration.GetConnectionString("InitMediaContextConnection"));
}
else
{
    string secret = await AWSSecretManager.GetSecret();
    builder.Services.AddMediaContext(secret);
}

builder.Logging.ClearProviders();

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

var loggerOptions = new LambdaLoggerOptions(configuration);

builder.Logging.AddLambdaLogger(loggerOptions);

builder.Logging.AddConsole();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddRepositories();

builder.Services.AddApplicationCore();

var app = builder.Build();

app.UseHttpsRedirection();

if (!builder.Environment.IsDevelopment())
{
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            switch (exceptionHandlerPathFeature?.Error)
            {
                case ArtistNotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync("The artist not found");
                    break;
                case TrackNotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync("The track not found");
                    break;
                case ReleaseNotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync("The release not found");
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        });
    });
}

app.MapGet("/tracks/{id}", async (IMediator mediator, long id) =>
{
    return await mediator.Send(new GetTrackByIdQuery(id));
});

app.MapGet("/releases/{id}", async (IMediator mediator, long id) =>
{
    return await mediator.Send(new GetReleaseByIdQuery(id));
});

app.MapGet("/artists/{id}", async (IMediator mediator, long id) =>
{
    return await mediator.Send(new GetArtistByIdQuery(id));
});

app.MapGet("/tracks", async (IMediator mediator) =>
{
    return await mediator.Send(new GetTracksQuery());
});

app.MapGet("/releases", async (IMediator mediator) =>
{
    return await mediator.Send(new GetReleasesQuery());
});

app.MapGet("/artists", async (IMediator mediator) =>
{
    return await mediator.Send(new GetArtistsQuery());
});

app.MapPost("artists", async (IMediator mediator, [FromBody] ArtistDto artistDto) =>
{
    return await mediator.Send(new AddArtistCommand(artistDto));
});

app.MapPost("releases", async (IMediator mediator, [FromBody] ReleaseDto releaseDto) =>
{
    return await mediator.Send(new AddReleaseCommand(releaseDto));
});

app.MapPost("tracks", async (IMediator mediator, [FromBody] TrackDto trackDto) =>
{
    return await mediator.Send(new AddTrackCommand(trackDto));
});

app.MapDelete("tracks/{id}", async (IMediator mediator, long id) =>
{
    await mediator.Send(new DeleteTrackByIdCommand(id));
});

app.MapDelete("artists/{id}", async (IMediator mediator, long id) =>
{
    await mediator.Send(new DeleteArtistByIdCommand(id));
});

app.MapDelete("releases/{id}", async (IMediator mediator, long id) =>
{
    await mediator.Send(new DeleteReleaseByIdCommand(id));
});

app.Run();
