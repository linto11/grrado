using GRRADO.Shared.Abstractions.Persistence;
using GRRADO.Shared.Infrastructure.Persistence;
using Polly;
using DiagnosticsService.Application.Abstractions;
using DiagnosticsService.Domain.Entities;

namespace DiagnosticsService.Infrastructure.Persistence;

public class DiagnosticsUnitOfWork : BaseUnitOfWork, IDiagnosticsUnitOfWork
{
    private IRepository<VehicleIssue>? _vehicleIssues;
    private IRepository<DiagnosticRule>? _diagnosticRules;
    private IRepository<ImageDiagnostic>? _imageDiagnostics;

    public DiagnosticsUnitOfWork(DiagnosticsDbContext context, IAsyncPolicy databaseResiliencePolicy)
        : base(context, databaseResiliencePolicy) { }

    public IRepository<VehicleIssue> VehicleIssues =>
        _vehicleIssues ??= new BaseRepository<VehicleIssue>(_context);

    public IRepository<DiagnosticRule> DiagnosticRules =>
        _diagnosticRules ??= new BaseRepository<DiagnosticRule>(_context);

    public IRepository<ImageDiagnostic> ImageDiagnostics =>
        _imageDiagnostics ??= new BaseRepository<ImageDiagnostic>(_context);
}
