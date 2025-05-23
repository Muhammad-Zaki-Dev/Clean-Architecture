﻿using AutoMapper;
using Domain.Entities;
using Domain.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command
{
    public class CategoryCommandHandler : IRequestHandler<CreateCategoryCommand>, IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {


            var category = mapper.Map<Category>(request);
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.CommitChanges();
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            unitOfWork.Categories.Update(category);
            await unitOfWork.CommitChanges();
        }
    }
}
