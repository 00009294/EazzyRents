using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.UseCases.RealEstates.Commands
{
    public record UpdateCommand(
        int Id,
        string Descriprion,
        double Price,
        List<IFormFile> Images,
        string PhoneNumber,
        string Email,
        string Longitude,
        string Latitude,
        string about,
        Address Address,
        RealEstateStatus Status
        ) : IRequest<bool>;

}
