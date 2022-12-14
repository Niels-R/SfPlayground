using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SfPlayground.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// OData
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Comment>("Comments");

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents("odata",
        modelBuilder.GetEdmModel()));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => 
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddHttpClient();

// Add services to the container.

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseRouting();
app.UseCors();

//app.UseEndpoints(endpoints => endpoints.MapControllers());

// app.UseHttpsRedirection();
//
// app.UseAuthorization();

app.MapControllers();

app.Run();