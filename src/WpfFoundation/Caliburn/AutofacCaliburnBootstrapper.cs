using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Caliburn.Micro;
using Microsoft.Extensions.Configuration;

namespace MarcellToth.WpfFoundation.Caliburn
{
    /// <summary>
    ///     A bootstrapper class for Caliburn Micro that handles the job of initializing an Autofac container.
    /// </summary>
    public abstract class AutofacCaliburnBootstrapper<TStartupViewModel> : BootstrapperBase
    {
        private IContainer _autofacContainer;
        
        /// <summary>
        ///     Configuration data loaded from appsettings.json (if available) and environment variables.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     Initializes the Caliburn Micro framework.
        /// </summary>
        protected AutofacCaliburnBootstrapper(bool useApplication = true) : base(useApplication)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            
            Initialize();
        }

        /// <inheritdoc />
        protected sealed override void Configure()
        {
            var containerBuilder = new ContainerBuilder();

            ConfigureContainer(containerBuilder);
            
            _autofacContainer = containerBuilder.Build();
        }

        /// <summary>
        ///     Override and extend this method to add your own services to the Autofac container.
        ///     This implementation adds ViewModels from <typeparamref name="TStartupViewModel"/>'s namespace,
        ///     and Views from the corresponding ../.Views namespace, along with <see cref="WindowManager"/> and <see cref="EventAggregator"/>,
        ///     so be sure to call <code>base.ConfigureContainer(containerBuilder)</code> unless you want to change this behavior.
        /// </summary>
        /// <param name="containerBuilder">A <see cref="ContainerBuilder"/> which the implementor should use to add their services, etc.</param>
        protected virtual void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            Type viewModelType = typeof(TStartupViewModel);
            Assembly viewModelAssembly = viewModelType.Assembly;
            
            Debug.Assert(viewModelType.Namespace != null, "viewModelType.Namespace != null");
            
            // The application namespace is the namespace of TStartupViewModel except the .ViewModels postfix.
            var namespaceParts = viewModelType.Namespace.Split('.');
            string applicationNamespace = string.Join(".", namespaceParts.Take(namespaceParts.Length-1));
            
            containerBuilder.RegisterAssemblyTypes(viewModelAssembly)
                .Where(t => t.Namespace != null && t.Namespace.StartsWith($"{applicationNamespace}.ViewModels"))
                .AsSelf();
            
            containerBuilder.RegisterAssemblyTypes(viewModelAssembly)
                .Where(t => t.Namespace != null && t.Namespace.StartsWith($"{applicationNamespace}.Views"))
                .AsSelf();
            
            
            containerBuilder.RegisterType<WindowManager>().As<IWindowManager>();
            containerBuilder.RegisterType<EventAggregator>().As<IEventAggregator>();
        }

        /// <inheritdoc />
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<TStartupViewModel>();
        }


        /// <inheritdoc />
        protected sealed override object GetInstance(Type service, string key)
        {
            if (string.IsNullOrEmpty(key))
                return _autofacContainer.Resolve(service);
            return _autofacContainer.ResolveNamed(key, service);
        }

        /// <inheritdoc />
        protected sealed override IEnumerable<object> GetAllInstances(Type service)
        {
            yield return _autofacContainer.Resolve(service);
        }
    }
}