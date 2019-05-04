using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarcellToth.WpfFoundation.Autofac
{
    /// <summary>
    ///     Extensions for Autofac's <see cref="ContainerBuilder"/>.
    /// </summary>
    public static class ConatinerBuilderExtensions
    {
        /// <summary>
        ///     Configures Options classes on <paramref name="builder"/> just like the method on <see cref="ServiceCollection"/> for ASP.NET Core.
        /// </summary>
        /// <remarks>
        ///     Calling this method makes an <code>IOptions&lt;TOptionsType&gt;</code>, <code>IOptionsSnapshot&lt;TOptionsType&gt;</code> and <code>IOptionsMonitor&lt;TOptionsType&gt;</code> available in the Autofac container.
        /// </remarks>
        /// <param name="builder">A <see cref="ContainerBuilder"/> instance.</param>
        /// <param name="configuration">The source of the options. Usually the result of a <code>GetSection</code> call.</param>
        /// <typeparam name="TOptionsType">The type of the options class to add to the builder.</typeparam>
        /// <returns><paramref name="builder"/></returns>
        public static ContainerBuilder Configure<TOptionsType>(this ContainerBuilder builder, IConfiguration configuration)
            where TOptionsType : class
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<TOptionsType>(configuration);
            builder.Populate(serviceCollection);
            return builder;
        }
    }
}