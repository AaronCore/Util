using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Helpers;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;

namespace Util.Generators.Razor.Tests.Integration {
    /// <summary>
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��������
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null )
                .ConfigureHostConfiguration( builder => {
                    Environment.SetDevelopment();
                } )
                .AddUtil( t => t.UseSerilog() );
        }

		/// <summary>
		/// ���÷���
		/// </summary>
		public void ConfigureServices( IServiceCollection services ) {
			services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		}
	}
}
