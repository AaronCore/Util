using EasyCaching.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Xunit.DependencyInjection.Logging;

namespace Util.Caching.EasyCaching; 

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        hostBuilder.ConfigureDefaults( null )
            .AddUtil( options => {
                Util.Helpers.Environment.SetDevelopment();
                var redisEndpoint = Util.Helpers.Environment.IsDevelopment() ? "192.168.31.157" : "redis.common";
                options.UseAop()
                    .UseRedisCache( t => {
                        t.MaxRdSecond = 0;
                        t.DBConfig.AllowAdmin = true;
                        t.DBConfig.KeyPrefix = "test:";
                        t.DBConfig.Endpoints.Add( new ServerEndPoint( redisEndpoint, 6379 ) );
                    } )
                    .UseMemoryCache( t => t.MaxRdSecond = 0 );
            } );
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}