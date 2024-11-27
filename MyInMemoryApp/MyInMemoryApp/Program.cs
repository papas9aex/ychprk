using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyInMemoryApp; // Убедитесь, что пространство имен корректное

var builder = WebApplication.CreateBuilder(args);

// Регистрация InMemoryDataStore как синглтона для хранения данных в памяти
builder.Services.AddSingleton<InMemoryDataStore>();

// Регистрация контроллеров с опцией использования MyJsonContext для сериализации
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolver = MyJsonContext.Default;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
