using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("punishment")]
    public partial class Punishment
    {
        [Key]
        [Column("punish_id")]
        public int PunishId { get; set; }
        [Column("punish_type")]
        [StringLength(50)]
        public string PunishType { get; set; }
        [Column("player_id")]
        public int? PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Punishments")]
        public virtual Player Player { get; set; }
    }
}
