using Aiko.Repository.Context;
using Aiko.Repository.Services.Interface;
using Aiko.Repository.Services.Repository;
using Aiko_teste.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.EnableAnnotations(); // Habilita leitura das anotações Swagger

    c.SchemaFilter<SwaggerIgnoreFilter>();
});

//Adicionando o CORS
builder.Services.AddCors();



builder.Services.AddDbContext<DataContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("AikoTeste")));

//injetando dependencias
builder.Services.AddScoped<IPlayService, PlayService>();
builder.Services.AddScoped<IPerformanceService, PerformanceService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IExtratoService, ExtratoService>();
builder.Services.AddScoped<IUtil, Util>();

//builder.Services.AddSingleton<IWebHostEnvironment>();

//injetando o AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "weather api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapControllers();

app.Run();
