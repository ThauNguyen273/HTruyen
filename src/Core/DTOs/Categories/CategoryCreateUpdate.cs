using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Categories
{
    public record struct  CategoryCreateUpdate
    {
        public required string Name { get; set; }
    }
}
