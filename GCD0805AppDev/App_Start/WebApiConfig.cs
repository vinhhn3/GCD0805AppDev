using GCD0805AppDev.Repositories;
using GCD0805AppDev.Repositories.IRepository;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace GCD0805AppDev
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      var container = new UnityContainer();
      container.RegisterType<ITodoRepository, TodoRepository>(new HierarchicalLifetimeManager());
      container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());

      //config.DependencyResolver = new UnityResolver(container);
      config.DependencyResolver = new UnityDependencyResolver(container);

      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
