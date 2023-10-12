﻿using BlackSun.API;
using BlackSun.Core.Extensions;
using BlackSun.Core.Handlers;
using BlackSun.Core.Repositories;
using BlackSun.Core.Services;
using BlackSun.Database.Contexts;
using BlackSun.Database.Extensions;
using BlackSun.Database.Models;
using BlackSun.Server.Areas.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Mime;

namespace BlackSun;

public class Startup
{
    private const string ConnectionStringName = "BlackSunConnectionString";
    private readonly bool _isProduction;

    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IHostEnvironment enviroment)
    {
        Configuration = configuration;
        _isProduction = enviroment.IsProduction();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString(ConnectionStringName) ?? throw new InvalidOperationException($"Connection string {ConnectionStringName} not found.");
        services.AddDatabaseContext(connectionString)
            .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>()
            .AddClassesWithInterfaces(new[] { typeof(IHandler<,>), typeof(IAsyncHandler<,>), typeof(IService), typeof(Repository<>) }, new[] { typeof(AssemblyAnchor).Assembly });

        services.AddAutoMapper(typeof(Program));
        // TODO: Добавить
        //services.AddDefaultIdentity<User>(options =>
        //{
        //    options.Password.RequiredLength = 6;
        //    options.Password.RequireLowercase = false;
        //    options.Password.RequireUppercase = false;
        //    options.Password.RequireNonAlphanumeric = false;
        //    options.Password.RequireDigit = false;
        //    options.SignIn.RequireConfirmedEmail = true;
        //}).AddRoles<Role>();

        RegisterBlazor(services);

        // TODO: Добавить
        //services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //});

        services.AddHttpContextAccessor();
        services.AddScoped<HttpContextAccessor>();

        // TODO: Добавить
        //services.AddScoped<UiLocker>();
        //services.AddScoped<LocalStorage>();
        //services.AddBlazoredLocalStorage();

        services.AddAuthorization();

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = false;
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            };
        });

        services.AddResponseCompression(options =>
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { MediaTypeNames.Application.Octet });
        });

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromDays(1);
        });

        services.AddHttpClient();
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddMvcCore();

        // TODO: Добавить
        //services
        //.AddBlazoredLocalisation()
        //.AddScrollListener()
        //.AddPopupService()
        //.AddDataTableMediatorServices()
        //.AddHostService()
        //.AddFilterSettingsService()
        //.RegisterCipherParser(Configuration);

        services.AddSignalR(options =>
        {
            options.MaximumReceiveMessageSize = 1_024_000L;
        });

        //services.AddOptions(Configuration);
    }

    private static void RegisterBlazor(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        // TODO: Добавить
        //services.AddLiveReload(config =>
        //{
        //    config.LiveReloadEnabled = true;
        //    config.ClientFileExtensions = ".css,.js,.htm,.html";
        //    config.FolderToMonitor = "~/../";
        //});
        //services.AddScoped<TokenAuthenticationStateProvider>();
        //services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<TokenAuthenticationStateProvider>());
    }

    // ToDo: avoid migration on service start - use dedicated job in CI/CD and run like this only on local debug
    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        using var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

        context.Database.Migrate();
    }

    private void CreateUploadFolder()
    {
        var uploadFolder = Configuration["UploadFolder"];
        if (uploadFolder == null)
            return;

        Directory.CreateDirectory(uploadFolder);
    }

    public void Configure(IServiceProvider serviceProvider, IApplicationBuilder app, IWebHostEnvironment env)
    {
        var russianCulture = new CultureInfo("ru-RU");
        var supportedCultures = new[] { russianCulture };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("ru-RU"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });
        app.UseResponseCompression();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
#if Watch
    app.UseLiveReload();
#endif
        UpdateDatabase(serviceProvider);
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");

            // TODO: Добавить
            //var hangfireOptions = serviceProvider.GetRequiredService<IOptions<HangfireOptions>>();
            //if (hangfireOptions.Value.Dashboard.Enabled)
            //{
            //    endpoints.MapJobsDashboard();
            //}
        });

        CreateUploadFolder();

        //ValidatorOptions.Global.LanguageManager.Culture = russianCulture;
        //ValidatorOptions.Global.DisplayNameResolver = (_, memberInfo, _) => memberInfo.GetDisplayString();

        RunJobs(serviceProvider);
    }

    private static void RunJobs(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        //var uploadReportsToMinioJobCron = serviceScope.ServiceProvider.GetRequiredService<IOptions<SendReportsToSInfoPulsarJobOptions>>().Value.Cron;
        //var updateHolidaysJobCron = serviceScope.ServiceProvider.GetRequiredService<IOptions<UpdateHolidaysJobOptions>>().Value.Cron;

        // TODO: Добавить
        //var recurringJobManager = serviceScope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

        //recurringJobManager.AddOrUpdate<SendReportsToSInfoPulsarJob>("SendReportsToSInfoPulsarJob", _ => _.Execute(), uploadReportsToMinioJobCron);
        //recurringJobManager.AddOrUpdate<UpdateHolidaysJob>("UpdateHolidaysJob", _ => _.Execute(), updateHolidaysJobCron);
    }
}