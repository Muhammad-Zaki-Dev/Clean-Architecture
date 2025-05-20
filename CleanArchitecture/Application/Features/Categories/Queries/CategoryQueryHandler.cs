using Application.DTOs;
using AutoMapper;
using Domain.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries
{
    public class CategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDTO>,IRequestHandler<GetAllCategoriesQuery,List<CategoryDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.Categories.GetByIdAsync(request.Id);
            return mapper.Map<CategoryDTO>(category);
        }
        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories= await unitOfWork.Categories.GetAllAsync();
            return mapper.Map<List<CategoryDTO>>(categories);
        }

    }
}
