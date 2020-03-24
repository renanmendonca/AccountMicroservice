using Account.Application.Services;
using Account.Domain.Interfaces.Repositories;
using Account.Infra.Data;
using Account.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;

namespace Account.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IAccountReadRepository, AccountReadRepository>();
            services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
            services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            var assembly = AppDomain.CurrentDomain.Load("Account.Application");
            services.AddMediatR(assembly);

            services.AddControllers()
                    .AddJsonOptions(opts =>
                    {
                        opts.JsonSerializerOptions.IgnoreNullValues = true;
                        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Account Api", Version = "v1" });
            });

            services.AddHealthChecks();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddApiVersion();

            return services;
        }

        private static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddScoped<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
    }
}
