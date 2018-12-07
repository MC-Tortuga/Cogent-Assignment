using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Cogent.Authorization;

namespace Cogent
{
    [DependsOn(
        typeof(CogentCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CogentApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CogentAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CogentApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
