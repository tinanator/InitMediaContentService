using InitMediaContentService.Application.Extensions;
using InitMediaContentService.Domain.Extensions;
using InitMediaContentService.Infrastructure.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using InitMediaContentService.Application.Queries;
using InitMediaContentService.Application.Commands;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService;

var builder = WebApplication.CreateBuilder(args);

string secret = await AWSSecretManager.GetSecret();

builder.Services.AddMediaContext(secret);

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddRepositories();

builder.Services.AddApplicationCore();

var app = builder.Build();

app.UseHttpsRedirection();

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
