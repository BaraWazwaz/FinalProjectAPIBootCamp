using FinalProjectAPIBootCamp.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = "Server=db40980.databaseasp.net; Database=db40980; User Id=db40980; Password=3z_QX9e?6f!T; Encrypt=False; MultipleActiveResultSets=True;";
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

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
