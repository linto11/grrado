using AutoMapper;
using LoggingService.Application.DTOs;
using LoggingService.Application.UseCases.AuditLogs.CreateAuditLog;
using LoggingService.Application.UseCases.AuditLogs.UpdateAuditLog;
using LoggingService.Application.UseCases.ErrorLogs.CreateErrorLog;
using LoggingService.Application.UseCases.ErrorLogs.UpdateErrorLog;
using LoggingService.Application.UseCases.ActivityLogs.CreateActivityLog;
using LoggingService.Application.UseCases.ActivityLogs.UpdateActivityLog;
using LoggingService.Application.UseCases.RequestResponseLogs.CreateRequestResponseLog;
using LoggingService.Application.UseCases.RequestResponseLogs.UpdateRequestResponseLog;
using LoggingService.Application.UseCases.ErrorMessages.CreateErrorMessage;
using LoggingService.Application.UseCases.ErrorMessages.UpdateErrorMessage;
using LoggingService.Domain.Entities;

namespace LoggingService.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuditLog, AuditLogDto>();
        CreateMap<CreateAuditLogCommand, AuditLog>();
        CreateMap<UpdateAuditLogCommand, AuditLog>();

        CreateMap<ErrorLog, ErrorLogDto>();
        CreateMap<CreateErrorLogCommand, ErrorLog>();
        CreateMap<UpdateErrorLogCommand, ErrorLog>();

        CreateMap<ActivityLog, ActivityLogDto>();
        CreateMap<CreateActivityLogCommand, ActivityLog>();
        CreateMap<UpdateActivityLogCommand, ActivityLog>();

        CreateMap<RequestResponseLog, RequestResponseLogDto>();
        CreateMap<CreateRequestResponseLogCommand, RequestResponseLog>();
        CreateMap<UpdateRequestResponseLogCommand, RequestResponseLog>();

        CreateMap<ErrorMessage, ErrorMessageDto>();
        CreateMap<CreateErrorMessageCommand, ErrorMessage>();
        CreateMap<UpdateErrorMessageCommand, ErrorMessage>();
    }
}
