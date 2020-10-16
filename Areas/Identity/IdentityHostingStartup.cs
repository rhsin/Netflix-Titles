using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcTitle.Areas.Identity.Data;
using MvcTitle.Data;

[assembly: HostingStartup(typeof(MvcTitle.Areas.Identity.IdentityHostingStartup))]
namespace MvcTitle.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MvcContextConnection")));

                services.AddDefaultIdentity<MvcTitleUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MvcContext>();
            });
        }
    }
}