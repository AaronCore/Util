namespace Util.Microservices.HealthChecks.EntityFrameworkCore;

/// <summary>
/// ������Ԫ�������
/// </summary>
/// <typeparam name="TUnitOfWork">������Ԫ����</typeparam>
public class UnitOfWorkHealthCheck<TUnitOfWork> : IHealthCheck where TUnitOfWork : IUnitOfWork {
    /// <summary>
    /// ������Ԫ
    /// </summary>
    private readonly TUnitOfWork _unitOfWork;

    /// <summary>
    /// ��ʼ��������Ԫ�������
    /// </summary>
    /// <param name="unitOfWork">������Ԫ</param>
    public UnitOfWorkHealthCheck( TUnitOfWork unitOfWork ) {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="context">�������������</param>
    /// <param name="cancellationToken">ȡ������</param>
    public async Task<HealthCheckResult> CheckHealthAsync( HealthCheckContext context, CancellationToken cancellationToken = default ) {
        context.CheckNull( nameof( context ) );
        try {
            var healthy = await _unitOfWork.CanConnectAsync( cancellationToken );
            return healthy ? HealthCheckResult.Healthy() : new HealthCheckResult( context.Registration.FailureStatus );
        }
        catch ( Exception exception ) {
            return HealthCheckResult.Unhealthy( exception.Message, exception );
        }
    }
}
