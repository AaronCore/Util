using Hangfire;
using Util;
using Util.Logging.Serilog;
using Util.Scheduling;
using Util.Scheduling.Hangfire.Sample.Services;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

builder.Services.AddHostedService<HostService2>();

//���Hangfire����
builder.Host.AddUtil( options => {
    options.UseSerilog()
    .UseHangfire( configuration => configuration
        .UseSqlServerStorage( builder.Configuration.GetConnectionString( "HangfireConnection" ) ),false
    );
} );

//���Mvc����
builder.Services.AddMvc();

//����WebӦ�ó���
var app = builder.Build();

//��������ܵ�
if ( !app.Environment.IsDevelopment() ) {
    app.UseExceptionHandler( "/Error" );
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints( endpoints => {
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
} );

//����Ӧ��
app.Run();
