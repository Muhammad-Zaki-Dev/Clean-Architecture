using Domain.Entities;
using Domain.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.Create
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateCategoryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Status = request.Status
            };
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.CommitChanges();


        }
    }
}
