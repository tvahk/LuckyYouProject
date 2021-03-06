[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebService.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebService.App_Start.NinjectWebCommon), "Stop")]

namespace WebService.App_Start
{
    using System;
    using System.Web;


    using Ninject;
    using Ninject.Web.Common;
    using DAL.Interfaces;
    using DAL;
    using DAL.Helpers;
    using Microsoft.AspNet.Identity;
    using Identity;
    using DomainLogic.IdentityModels;
    using Microsoft.Owin.Security;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            //DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            //DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<LuckyYouDbContext>().InRequestScope();
            //kernel.Bind<IDbContextFactory>().To<DbContextFactory>().InRequestScope();

            kernel.Bind<EFRepositoryFactories>().To<EFRepositoryFactories>().InSingletonScope();
            kernel.Bind<IEFRepositoryProvider>().To<EFRepositoryProvider>().InRequestScope();
            kernel.Bind<IUOW>().To<UOW>().InRequestScope();

            kernel.Bind<IUserStore<User>>().To<UserStore<User>>();
            kernel.Bind<IRoleStore<Role>>().To<RoleStore<Role>>();

            //kernel.Bind<ApplicationSignInManager>().To<ApplicationSignInManager>();
            kernel.Bind<ApplicationUserManager>().To<ApplicationUserManager>();
            //kernel.Bind<ApplicationRoleManager>().To<ApplicationRoleManager>();

            kernel.Bind<IAuthenticationManager>().ToMethod(a => HttpContext.Current.GetOwinContext().Authentication);
        }     
    }
}
