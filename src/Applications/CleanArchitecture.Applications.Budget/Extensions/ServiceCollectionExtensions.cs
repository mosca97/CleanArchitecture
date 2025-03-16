// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Applications.Budget.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBudgetApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            return services;
        }
    }
}
