using Abstractions.DTOs.AiUsageLog;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Chatbot;

public interface IAiUsageLogService : IBaseService<AiUsageLog, AiUsageLogDto, CreateAiUsageLogRequest, UpdateAiUsageLogRequest>
{
}

public class AiUsageLogService : BaseService<AiUsageLog, AiUsageLogDto, CreateAiUsageLogRequest, UpdateAiUsageLogRequest>, IAiUsageLogService
{
    public AiUsageLogService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    protected override IRepository<AiUsageLog> GetRepository() => _unitOfWork.AiUsageLogs;}
