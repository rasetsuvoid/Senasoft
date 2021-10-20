using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senasoft.Models
{
    public class FacturasModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Primer Nombre")]
        public string FirstName { get; set; }

        public string Resume { get; set; }
        public int IdFactura { get; set; }

        [ForeignKey("IdFactura")]
        public virtual TiposFacturasModel TiposFacturaModel { get; set; }

    }
}
