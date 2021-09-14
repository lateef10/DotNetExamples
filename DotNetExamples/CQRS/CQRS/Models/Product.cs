using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
    }
}
