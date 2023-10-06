using ETicaretAPI.api.Filters.TokenValidationActionFilter;
using ETicaretAPI.api.Middlewares;
using ETicaretAPI.application.DTOs.Mail;
using ETicaretAPI.application.Extensions;
using ETicaretAPI.application.Validators;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.infrastructure.Extensions;
using ETicaretAPI.infrastructure.Filters;
using ETicaretAPI.persistence.Extensions;
using ETicaretAPI.persistence.Hubs;
using ETicaretAPI.persistence.Subscription;
using ETicaretAPI.persistence.Subscription.Middleware;
using ETicaretAPI.signalr.Extensions;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers(options =>
{
    options.Filters.Add<TokenValidationFilter>();
    options.Filters.Add<ValidationFilter>();
})
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    })
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    });

var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddAuthentication();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddPersistenceLayerServices();

builder.Services.AddApplicationLayerServices();

builder.Services.AddInfrastructureLayerServices();

builder.Services.AddDirectoryBrowser();

builder.Services.AddSignalRServices();

List<string> tokens = new List<string>();
builder.Services.AddScoped<List<string>>(provider => tokens);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7263")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHsts();

app.UseStaticFiles();

app.UseDatabaseSubscription<DatabaseSubscription<Product>>("Products");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ProductHub>("/productHub");
});

app.MapHubs();

//app.PersistenceApp();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseMiddleware<GlobalRequestHandlerMiddleware>();

app.MapControllers();

app.UseStaticFiles();

app.Run();