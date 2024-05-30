using AutoMapper;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Shared;
using Microsoft.Extensions.Localization;

namespace JEPCO.Application.Services.Reseller;

public class ResellerAppService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IStringLocalizer<SharedResource> localizer;
    public ResellerAppService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> localizer, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.localizer = localizer;
        this.mapper = mapper;
    }
}
