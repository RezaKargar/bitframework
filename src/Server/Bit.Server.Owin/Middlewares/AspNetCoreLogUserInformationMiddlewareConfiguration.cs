﻿using Bit.Owin.Contracts;
using Microsoft.AspNetCore.Builder;
using System;

namespace Bit.Owin.Middlewares
{
    public class AspNetCoreLogUserInformationMiddlewareConfiguration : IAspNetCoreMiddlewareConfiguration
    {
        public virtual MiddlewarePosition MiddlewarePosition => MiddlewarePosition.BeforeOwinMiddlewares;

        public virtual void Configure(IApplicationBuilder aspNetCoreApp)
        {
            if (aspNetCoreApp == null)
                throw new ArgumentNullException(nameof(aspNetCoreApp));

            aspNetCoreApp.UseMiddleware<AspNetCoreLogUserInformationMiddleware>();
        }
    }
}
