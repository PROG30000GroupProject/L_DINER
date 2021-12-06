using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public interface ISideRepository
    {
        IQueryable<Side> Sides { get; }
    }
}
