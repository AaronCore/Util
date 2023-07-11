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
        Util.Helpers.Environment.SetDevelopment();
        var redisEndpoint = Util.Helpers.Environment.IsDevelopment() ? "127.0.0.1" : "redis.common";
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddAop()
            .AddRedisCache( t => {
                t.MaxRdSecond = 0;
                t.DBConfig.AllowAdmin = true;
                t.DBConfig.KeyPrefix = "test:";
                t.DBConfig.Endpoints.Add( new ServerEndPoint( redisEndpoint, 6379 ) );
            } )
            .AddMemoryCache( t => t.MaxRdSecond = 0 )
            .AddUtil();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}