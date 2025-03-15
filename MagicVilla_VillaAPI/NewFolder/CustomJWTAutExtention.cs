using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MagicVilla_VillaAPI.NewFolder
{
    public static class CustomJWTAutExtention
    {
        public static void AddCustomJWT(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddAuthentication(ml =>
            {
                ml.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                ml.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                ml.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(ml =>
            {
                ml.RequireHttpsMetadata = false;
                ml.SaveToken = true;
                ml.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
                };
            });
        }
    }
}
