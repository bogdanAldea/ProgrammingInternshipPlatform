
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingInternshipPlatform.Api.Contracts.ApiErrorResponse;
using ProgrammingInternshipPlatform.Application.InternshipManagement.SetupNewInternshipProgram;
using ProgrammingInternshipPlatform.Dal.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = ApiErrorResponse.CreateErrorResponse;
});

builder.Services.AddMediatR(typeof(SetupNewInternshipProgramCommand));

builder.Services.AddDbContext<ProgrammingInternshipPlatformDbContext>
(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProgrammingInternshipPlatformDatabase"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

var app = builder.Build();

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