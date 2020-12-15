using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("result")]
    public partial class Result
    {
        [Key]
        [Column("match_id")]
        public int MatchId { get; set; }
        [Key]
        [Column("team_id")]
        public int TeamId { get; set; }
        [Column("result")]
        [StringLength(50)]
        public string Result1 { get; set; }
        [Column("M_red_card")]
        public int? MRedCard { get; set; }
        [Column("M_yel_card")]
        public int? MYelCard { get; set; }
        [Column("M_goals")]
        public int? MGoals { get; set; }

        [ForeignKey(nameof(MatchId))]
        [InverseProperty("Results")]
        public virtual Match Match { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("Results")]
        public virtual Team Team { get; set; }
    }
}
