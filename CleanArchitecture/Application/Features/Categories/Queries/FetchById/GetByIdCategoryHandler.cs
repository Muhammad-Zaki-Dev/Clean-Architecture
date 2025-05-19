using Application.DTOs;
using AutoMapper;
using Domain.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.FetchById
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetByIdCategoryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(request.Id);
            return mapper.Map<CategoryDTO>(category);
        }

       
    }
}
