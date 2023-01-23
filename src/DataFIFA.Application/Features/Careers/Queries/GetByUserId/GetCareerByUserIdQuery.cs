﻿using DataFIFA.Application.ViewModels.Careers;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetByUserId;

public class GetCareerByUserIdQuery : IRequest<List<CareerViewModel>?>
{
    public GetCareerByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; set; }
}