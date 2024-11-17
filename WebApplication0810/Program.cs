using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApplication0810.Models.EFModels;
using WebApplication0810.Service;
using WebApplication0810.Service.DapperService;
using WebApplication0810.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 加入 DbContext 到 DI 容器中
builder.Services.AddDbContext<_0810Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DapperMemberService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new DapperMemberService(new SqlConnection(connectionString));
});


// 加入 Table0810Service 到 DI 容器中
builder.Services.AddScoped<Table0810Service>();

// 注册 QuestionAnswerService 为单例
builder.Services.AddSingleton<QuestionAnswerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
