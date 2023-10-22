using MoviesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddTransient<IRepository, InMemoryRepository>();
// Everytime IRepository is used, new instance is created
// Initialize value will remain same as each new instance is created, maybe or may not be what you want.

//builder.Services.AddScoped<IRepository, InMemoryRepository>();
// Each instance per http request call, everytime new request, the value will be reinitiated

// Only single instance will be initiazed and used
builder.Services.AddSingleton<IRepository, InMemoryRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// App go in sequence, from first defined to last defined, so middleware should be at first
var app = builder.Build();

app.Use(async (context, next) =>
{
    using (var swapStream = new MemoryStream())
    {
        var originalResponseBody = context.Response.Body;
        context.Response.Body = swapStream;

        await next.Invoke();
    }
});

// Middleware to intercept the request to certain end point using map
app.Map("/map1", (app) =>
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("I'm short-circuting the pipeline");
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

