using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities
{
    [Table("TB_LOGSISTEMA")]
    public class LogSistema : Base
    {
        [Column("LOG_JSONINFORMACAO")]
        [Display(Name = "Json Informação")]
        public string JsonInformacao { get; set; }

        [Column("LOG_TIPOLOG")]
        [Display(Name = "Tipo Log")]
        public EnumTipoLog TipoLog { get; set; }

        [Column("LOG_CONTROLLER")]
        [Display(Name = "Nome Controller")]
        public string NomeController { get; set; }

        [Column("LOG_ACTION")]
        [Display(Name = "Nome Action")]
        public string NomeAction { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
