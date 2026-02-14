using AutoMapper;
using DiagnosticsService.Application.DTOs;
using DiagnosticsService.Application.UseCases.VehicleIssues.CreateVehicleIssue;
using DiagnosticsService.Application.UseCases.VehicleIssues.UpdateVehicleIssue;
using DiagnosticsService.Application.UseCases.DiagnosticRules.CreateDiagnosticRule;
using DiagnosticsService.Application.UseCases.DiagnosticRules.UpdateDiagnosticRule;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.CreateImageDiagnostic;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.UpdateImageDiagnostic;
using DiagnosticsService.Domain.Entities;

namespace DiagnosticsService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VehicleIssue, VehicleIssueDto>();
        CreateMap<CreateVehicleIssueCommand, VehicleIssue>();
        CreateMap<UpdateVehicleIssueCommand, VehicleIssue>();

        CreateMap<DiagnosticRule, DiagnosticRuleDto>();
        CreateMap<CreateDiagnosticRuleCommand, DiagnosticRule>();
        CreateMap<UpdateDiagnosticRuleCommand, DiagnosticRule>();

        CreateMap<ImageDiagnostic, ImageDiagnosticDto>();
        CreateMap<CreateImageDiagnosticCommand, ImageDiagnostic>();
        CreateMap<UpdateImageDiagnosticCommand, ImageDiagnostic>();
    }
}
