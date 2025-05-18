using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Categories.Command.Create
{
    public class CreateCategoryCommand:IRequest

    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
