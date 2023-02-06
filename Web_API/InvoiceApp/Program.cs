using Infrastructure.Repositories;
using Services;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace InvoiceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddTransient<IInvoiceService, InvoiceService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // jwt
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey
            //            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = false,
            //        ValidateIssuerSigningKey = true
            //    };
            //});
            //builder.Services.AddAuthorization();

            ////adding cors policy
            //builder.Services.AddCors();
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "AllowOrigin",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://127.0.0.1:5500")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});

            //building
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });


            app.UseHttpsRedirection();

            //app.MapGet("/security/getMessage", () => "Hello World!").RequireAuthorization();
            //app.MapPost("/security/createToken",
            //[AllowAnonymous] (User user) =>
            //{
            //    if (user.UserName == "joydip" && user.Password == "joydip123")
            //    {
            //        var issuer = builder.Configuration["Jwt:Issuer"];
            //        var audience = builder.Configuration["Jwt:Audience"];
            //        var key = Encoding.ASCII.GetBytes
            //        (builder.Configuration["Jwt:Key"]);
            //        var tokenDescriptor = new SecurityTokenDescriptor
            //        {
            //            Subject = new ClaimsIdentity(new[]
            //            {
            //    new Claim("Id", Guid.NewGuid().ToString()),
            //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            //    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
            //    new Claim(JwtRegisteredClaimNames.Jti,
            //    Guid.NewGuid().ToString())
            //             }),
            //            Expires = DateTime.UtcNow.AddMinutes(5),
            //            Issuer = issuer,
            //            Audience = audience,
            //            SigningCredentials = new SigningCredentials
            //            (new SymmetricSecurityKey(key),
            //            SecurityAlgorithms.HmacSha512Signature)
            //        };
            //        var tokenHandler = new JwtSecurityTokenHandler();
            //        var token = tokenHandler.CreateToken(tokenDescriptor);
            //        var jwtToken = tokenHandler.WriteToken(token);
            //        var stringToken = tokenHandler.WriteToken(token);
            //        return Results.Ok(stringToken);
            //    }
            //    return Results.Unauthorized();
            //});

            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}