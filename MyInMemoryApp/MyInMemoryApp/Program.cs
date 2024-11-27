using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyInMemoryApp; // ���������, ��� ������������ ���� ����������

var builder = WebApplication.CreateBuilder(args);

// ����������� InMemoryDataStore ��� ��������� ��� �������� ������ � ������
builder.Services.AddSingleton<InMemoryDataStore>();

// ����������� ������������ � ������ ������������� MyJsonContext ��� ������������
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
