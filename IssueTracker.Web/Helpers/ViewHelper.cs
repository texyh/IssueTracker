using IssueTracker.Core.Enums;
using IssueTracker.Core.Interfaces;
using IssueTracker.Service;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Web.Helpers
{
    public class ViewHelper
    {
        public static IEnumerable<SelectListItem>  GetPrioritySelect(PriorityEnum id)
        {
            return Enum.GetValues(typeof(PriorityEnum))
                .Cast<PriorityEnum>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x == id
                });
        }

        public static IEnumerable<SelectListItem> GetStatusSelect(IssueStatusEnum id)
        {
            return Enum.GetValues(typeof(IssueStatusEnum))
                .Cast<IssueStatusEnum>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x == id
                });
        }
        //private static readonly IServiceProvider _provider;

        //public static IEnumerable<SelectListItem> GetDepartments(long id)
        //{
        //    var service = GetDepartmentService();
        //    var departments = service.GetDepartments();

        //    departments.Wait();

        //    var options = new List<SelectListItem>();

        //    options.AddRange(
        //        departments.Result.Select(x => new SelectListItem
        //        {
        //            Text = x.Name,
        //            Value = x.Id.ToString(),
        //            Selected = x.Id == id
        //        })
        //    );

        //    return options;
        //}

        //private static IIssueComposerService GetIssueService()
        //{
        //    return ServiceProviderFactory.ServiceProvider.GetServices(typeof(IIssueComposerService)) as IIssueComposerService;
        //}

        //private static IDepartmentComposerService GetDepartmentService()
        //{
        //    return _provider.GetService<IDepartmentComposerService>();
        //    //return ServiceProviderFactory.ServiceProvider.GetServices(typeof(IDepartmentComposerService)) as IDepartmentComposerService;
        //}

    }


    //internal static class ServiceProviderFactory
    //{
    //    //public static IServiceProvider ServiceProvider { get; }

    //    //static ServiceProviderFactory()
    //    //{
    //    //    HostingEnvironment env = new HostingEnvironment();
    //    //    env.ContentRootPath = Directory.GetCurrentDirectory();
    //    //    env.EnvironmentName = "Development";

    //    //    Startup startup = new Startup(env);
    //    //    ServiceCollection sc = new ServiceCollection();
    //    //    startup.ConfigureServices(sc);
    //    //    ServiceProvider = sc.BuildServiceProvider();
    //    //}
    //}
}
