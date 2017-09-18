using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UserTest.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace UserTest.Web.Host.Startup
{
    [DependsOn(
       typeof(UserTestWebCoreModule))]
    public class UserTestWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public UserTestWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserTestWebHostModule).GetAssembly());
        }
    }
}
