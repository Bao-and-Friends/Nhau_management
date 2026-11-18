using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.DAO;
using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Models.Configuration;
using RestaurantAPI.Services.Interface;
using System.Security.Claims;
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
            services.AddScoped<DbSession>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Nghiệp vụ (JWT, Mail, OTP)
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<MailService>();
            services.AddScoped<OTPService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IStaffService, StaffService>();
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
                    RoleClaimType = ClaimTypes.Role,
                    NameClaimType = ClaimTypes.Name,
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

