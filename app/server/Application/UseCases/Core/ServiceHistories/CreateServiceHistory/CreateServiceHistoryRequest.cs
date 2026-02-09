using Application.Common.Models;
using Abstractions.DTOs.ServiceHistory;
using MediatR;

namespace Application.UseCases.Core.ServiceHistories.CreateServiceHistory;

public class CreateServiceHistoryRequest : IRequest<Result<ServiceHistoryDto>>
{
    public int VehicleId { get; set; }
    public int GarageId { get; set; }
    public int? ServiceId { get; set; }
    public DateTime ServiceDate { get; set; }
    public double MileageAtService { get; set; }
    public decimal Cost { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
