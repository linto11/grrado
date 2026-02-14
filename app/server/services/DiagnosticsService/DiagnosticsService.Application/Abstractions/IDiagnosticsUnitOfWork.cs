using GRRADO.Shared.Abstractions.Persistence;
using DiagnosticsService.Domain.Entities;

namespace DiagnosticsService.Application.Abstractions;

public interface IDiagnosticsUnitOfWork : IUnitOfWork
{
    IRepository<VehicleIssue> VehicleIssues { get; }
    IRepository<DiagnosticRule> DiagnosticRules { get; }
    IRepository<ImageDiagnostic> ImageDiagnostics { get; }
}
