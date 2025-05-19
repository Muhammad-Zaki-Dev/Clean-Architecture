using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.FetchById
{
    public class GetByIdCategoryQuery:IRequest<CategoryDTO>
    {
        public Guid Id { get; set; }
    }
}
