using app.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureDependencyInjection(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureApiVersion();
builder.Services.ConfigureHealthCheck();
builder.Services.ConfigureCustomCors();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("Development");
}
else
{
    //alterar se for preciso para outro ambiente
    app.UseCors("Development");

}

app.UseHsts(); //usar somente https
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.MapControllers();


app.Run();
