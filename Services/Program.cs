using Microsoft.EntityFrameworkCore;
using NSS_API.Data;
using NSS_API.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Database Connection (AWS RDS) ko Register karo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Email Service ko Register karo
builder.Services.AddScoped<EmailService>();

// 3. Controllers support add karo (Iske bina AuthController nahi chalega)
builder.Services.AddControllers();

// 4. Swagger Setup (Testing ke liye)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Swagger UI enable karo
if (app.Environment.IsDevelopment() || true) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 6. Controllers ko Map karo
app.MapControllers();

app.Run();