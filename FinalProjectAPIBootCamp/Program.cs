using FinalProjectAPIBootCamp.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string localConnectionString = "Server=Bara-Desktop\\SQLEXPRESS;Database=TestingWithLaeth;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True";
string connectionString = "Server=db40980.public.databaseasp.net; Database=db40980; User Id=db40980; Password=3z_QX9e?6f!T; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(localConnectionString));

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
