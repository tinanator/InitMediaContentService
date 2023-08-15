using InitMediaContentService.Application.Extensions;
using InitMediaContentService.Domain.Extensions;
using InitMediaContentService.Infrastructure.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediaContext(builder.Configuration.GetConnectionString("InitMediaContextConnection"));

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddRepositories();

builder.Services.AddApplicationCore();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/tracks/{id}", async (IMediator mediator, Guid id) =>
{
    return await mediator.Send(new GetTrackByIdQuery(id));
});

app.MapGet("/releases/{id}", async (IMediator mediator, Guid id) =>
{
    return await mediator.Send(new GetReleaseByIdQuery(id));
});

app.MapGet("/artists/{id}", async (IMediator mediator, Guid id) =>
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

app.MapPost("artists/create", async (IMediator mediator, [FromBody] ArtistDTO artistDTO) =>
{
    await mediator.Send(new AddArtistCommand(artistDTO));
});

app.MapPost("releases/create", async (IMediator mediator, [FromBody] ReleaseDTO releaseDTO) =>
{
    await mediator.Send(new AddReleaseCommand(releaseDTO));
});

app.MapPost("tracks/create", async (IMediator mediator, [FromBody] TrackDTO trackDTO) =>
{
    await mediator.Send(new AddTrackCommand(trackDTO));
});

app.MapDelete("tracks/{id}", async (IMediator mediator, [FromBody] DeleteTrackByIdCommand command) =>
{
    await mediator.Send(command);
});

app.MapDelete("artists/{id}", async (IMediator mediator, [FromBody] DeleteArtistByIdCommand command) =>
{
    await mediator.Send(command);
});

app.MapDelete("releases/{id}", async (IMediator mediator, [FromBody] DeleteReleaseByIdCommand command) =>
{
    await mediator.Send(command);
});

app.Run();
