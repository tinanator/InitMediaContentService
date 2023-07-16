using InitMediaContentService.Commands;
using InitMediaContentService.Database;
using InitMediaContentService.Entities;
using InitMediaContentService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TrackContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Track>, Repository<Track>>();
builder.Services.AddScoped<IRepository<Release>, Repository<Release>>();
builder.Services.AddScoped<IRepository<Artist>, Repository<Artist>>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/tracks/{id}", async (IMediator mediator, int id) =>
{
    return await mediator.Send(new GetTrackByIdQuery(id));
});

app.MapGet("/tracks", async (IMediator mediator) =>
{
    return await mediator.Send(new GetTracksQuery());
});

app.MapPost("tracks/create", async (IMediator mediator, [FromBody] Track track) =>
{
    await mediator.Send(new AddTrackCommand(track));
});

app.MapDelete("tracks/{id}", async (IMediator mediator, [FromBody] DeleteTrackByIdCommand command) =>
{
    await mediator.Send(command);
});

app.Run();
