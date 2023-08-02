using Util.Logging.Serilog;

namespace Util.Microservices.Dapr.Tests; 

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Util.Helpers.Environment.SetDevelopment();
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddSerilog( "Util.Microservices.Dapr.Tests.Integration" )
            .AddDapr()
            .AddUtil();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
        Ioc.SetServiceProviderAction( services.BuildServiceProvider );
    }
}