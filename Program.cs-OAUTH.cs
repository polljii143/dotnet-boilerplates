using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiAppContext>(options =>
{
    options.UseSqlServer("ConnectionStringHere");
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = "ValidIssuerHere",
            ValidAudience = "ValidAudienceHere",
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes("SecretKeyHere")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrative",
        p => p.RequireRole("Superadmin", "Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
