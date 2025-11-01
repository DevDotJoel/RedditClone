using Modules.Posts.Infrastructure;
using RedditClone.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .AddPresentation()
    .AddPostModule(builder.Configuration);

// Add OpenAPI (keeping your existing setup)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline using the presentation layer
app.UsePresentation();

// Add OpenAPI mapping (keeping your existing setup)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
