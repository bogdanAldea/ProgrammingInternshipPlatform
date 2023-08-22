using ProgrammingInternshipPlatform.Api.Registrars;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");
  
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();