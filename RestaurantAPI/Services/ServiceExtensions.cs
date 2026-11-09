using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.DAO;
using RestaurantAPI.Data;
using RestaurantAPI.Models.Configuration;
using System.Text;

namespace RestaurantAPI.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRestaurantServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));
            services.Configure<JwtConfig>(configuration.GetSection("JwtSettings"));
            // Database & Repositories
            services.AddSingleton<DapperContext>();
            services.AddScoped<TableDAO>();
            services.AddScoped<AccountDAO>();
            services.AddScoped<StaffDAO>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Nghiệp vụ (JWT, Mail, OTP)
            services.AddScoped<AuthService>();
            services.AddScoped<MailService>();
            services.AddScoped<OTPService>();
            services.AddScoped<TableService>();
            services.AddScoped<AccountService>();
            services.AddScoped<StaffService>();
            return services;
        }
        // 2. Gom toàn bộ phần cấu hình JWT Token vào đây
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"]!;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}

