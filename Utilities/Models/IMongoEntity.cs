using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public interface IMongoEntity
    {
        string? Id { get; set; }
    }
}
