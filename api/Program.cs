using infra.extensions;

var builder = WebApplication.CreateBuilder(args);


var credentialsPath = builder.Configuration["Google:CredentialsPath"];
var tokenPath = builder.Configuration["Google:TokenPath"];

builder.Services.AddGoogleServices(credentialsPath, tokenPath);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
