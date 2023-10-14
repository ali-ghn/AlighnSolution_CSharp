using AlighnSolution.Configuration;
using AlighnSolution.Database;
using AlighnSolution.Email;
using AlighnSolution.SSO;
using AlighnSolution.User;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind(Configuration.JwtConfiguration, options));

builder.Services.AddIdentityMongoDbProvider<User, UserRole, string>(options => builder.Configuration.Bind(Configuration.IdentityMongoConfiguration, options));

builder.Services.AddSingleton<IGenericRepository<User>, GenericGenericRepository<User>>();
builder.Services.AddSingleton<IEmailService, EmailService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.Run();