using app.Api.Configuration;
using app.Api.Extensions.Filter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(config =>
{
    config.Filters.Add<TransactionFilter>();
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.ConfigureDependencyInjection(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureHealthCheck(builder.Configuration);
builder.Services.ConfigureApiVersion();
builder.Services.ConfigureCustomCors();
builder.Services.ConfigureSwagger();

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

app.UseHealthChecks("/hc", new HealthCheckOptions() { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

app.UseHealthChecksUI(option =>
{
    option.UIPath = "/hc-ui";
});
app.MapControllers();


app.Run();
