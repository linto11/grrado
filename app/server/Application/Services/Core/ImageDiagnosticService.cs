using Abstractions.DTOs.ImageDiagnostic;
using Abstractions.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Core;

public interface IImageDiagnosticService : IBaseService<ImageDiagnostic, ImageDiagnosticDto, CreateImageDiagnosticRequest, UpdateImageDiagnosticRequest>
{
}

public class ImageDiagnosticService : BaseService<ImageDiagnostic, ImageDiagnosticDto, CreateImageDiagnosticRequest, UpdateImageDiagnosticRequest>, IImageDiagnosticService
{
    public ImageDiagnosticService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override IRepository<ImageDiagnostic> GetRepository() => _unitOfWork.ImageDiagnostics;
}
