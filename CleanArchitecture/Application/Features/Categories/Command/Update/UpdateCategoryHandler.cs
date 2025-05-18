using Domain.Entities;
using Domain.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Command.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> repository;
        public UpdateCategoryHandler(IRepository<Category> repository)
        {
            this.repository = repository;

        }

        public  async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Status = request.Status,
                Id = request.Id
            };
           await repository.UpdateAsync(category);
        }
    }
}
