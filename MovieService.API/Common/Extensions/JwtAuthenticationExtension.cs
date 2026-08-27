using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Errors;
using MovieService.Application.Common.Settings;

namespace MovieService.API.Common.Extensions
{
    public static class JwtAuthenticationExtension
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // Have to use IConfiguration here, as IOptions<JwtSettings> is not available yet.
            // Tho registered once in program.cs, we have to bind it here.
            // Extentions like this, runs during service registration not runtime, thus:
            // DI container is still being built, IOptions<JwtSettings> may not be available yet
            var jwt =
                configuration.GetSection("Jwt").Get<JwtSettings>()
                ?? throw new InvalidOperationException("Jwt configuration is missing.");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Store token, can later be getting it with HttpContext.GetTokenAsync("access_token")
                    // Mainly needed for downstream calling other api with Authorize, not needed in this project
                    // options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwt.Audience,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwt.Key)
                        ),

                        // Removes buffer. Default is 5 min. Strict expiration check.
                        // Without removing, token expiresTime validation will allow a + 5min
                        // ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        // When request comes in, if there is no Token from Auth Header,
                        // Try to get value from Cookies
                        OnMessageReceived = context =>
                        {
                            if (
                                string.IsNullOrEmpty(context.Token)
                                && context.Request.Cookies.TryGetValue(
                                    "access_token",
                                    out var token
                                )
                            )
                            {
                                context.Token = token;
                            }

                            return Task.CompletedTask;
                        },

                        // If challenged
                        OnChallenge = async context =>
                        {
                            // Skip default response
                            context.HandleResponse();

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var response = ApiResponse<object>.Fail(
                                AuthErrors.AuthenticationFailedCode,
                                AuthErrors.AccesstokenInvalidMessage
                            );

                            await context.Response.WriteAsJsonAsync(response);
                        },

                        // On forbidden
                        OnForbidden = async context =>
                        {
                            // This does not to skip default reponse because ForBidden does not auto write response

                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";

                            var response = ApiResponse<object>.Fail(
                                AuthErrors.AuthorizationFailedCode,
                                AuthErrors.NoPermissionMessage
                            );

                            await context.Response.WriteAsJsonAsync(response);
                        },
                    };
                });

            // This registers DI / configuration, enables authorization system
            // app.UseAuthorization then RUNS that middleware execution before request pipeline
            services.AddAuthorization();

            return services;
        }
    }
}
