using Microsoft.Practices.Unity;
using System.Web.Http;
using TimeLogDataAccess.Interfaces;
using TimeLogDataAccess.Repositories;
using TimeLogDomain.Interfaces;
using TimeLogDomain.Services;
using Unity.WebApi;

namespace TimeLogWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITimeLogService, TimeLogService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}