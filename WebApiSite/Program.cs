using Entities.Entities;
using HelpConfig;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;
using WebApiSite.Token;

var builder = WebApplication.CreateBuilder(args);

//***************************************************** NOVO
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//*****************************************************

// ConfigureServices

builder.Services.AddDbContext<ContextBase>(options =>
              options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
HelpStartup.ConfigureSingleton(builder.Services);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(option =>
  {
      option.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,

          ValidIssuer = "Teste.Securiry.Bearer",
          ValidAudience = "Teste.Securiry.Bearer",
          IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
      };

      option.Events = new JwtBearerEvents
      {
          OnAuthenticationFailed = context =>
          {
              Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
              return Task.CompletedTask;
          },
          OnTokenValidated = context =>
          {
              Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
              return Task.CompletedTask;
          }
      };
  });

var app = builder.Build();
//Configure
//****************NOVO*************************************************
app.UseSwagger();
//****************NOVO*************************************************

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

//****************NOVO*************************************************
app.UseSwaggerUI();
//****************NOVO*************************************************

app.Run();
