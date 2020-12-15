using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("goals")]
    public partial class Goal
    {
        [Key]
        [Column("goal_id")]
        public int GoalId { get; set; }
        [Column("match_id")]
        public int? MatchId { get; set; }
        [Column("player_id")]
        public int? PlayerId { get; set; }
        [Column("team_id")]
        public int? TeamId { get; set; }

        [ForeignKey(nameof(MatchId))]
        [InverseProperty("Goals")]
        public virtual Match Match { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Goals")]
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("Goals")]
        public virtual Team Team { get; set; }
    }
}
