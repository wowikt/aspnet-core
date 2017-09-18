using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UserTest.Authorization;

namespace UserTest
{
    [DependsOn(
        typeof(UserTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UserTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UserTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(UserTestApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });

        }
    }
}