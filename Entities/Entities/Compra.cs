using Entities.Entities.Enums;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    [Table("TB_COMPRA")]
    public class Compra : Notifies
    {
        [Column("COM_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("COM_ESTADO")]
        [Display(Name = "Estado")]
        public EnumEstadoCompra Estado { get; set; }

        [Column("COM_DATA_COMPRA")]
        [Display(Name = "Data Compra")]
        public DateTime? DataCompra { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
