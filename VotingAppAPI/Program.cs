using Microsoft.EntityFrameworkCore;
using VotingAppAPI.Data;
using VotingAppAPI.Interfaces;
using VotingAppAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<VotingContext>(options =>
        options.UseSqlServer("Server=DESKTOP-U7C94O7\\SQLEXPRESS;Database=VotingAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", 
        builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddScoped<IVoters, VotersService>();
builder.Services.AddScoped<ICandidates, CandidatesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp"); // Enable the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
