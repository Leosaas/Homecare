using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Infrastructure.Entities
{
    [Table("Enterprise")]
    public class Enterprise
    {
        public long Id { get; set; }
    }
}
