using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("team")]
    public partial class Team
    {
        public Team()
        {
            Goals = new HashSet<Goal>();
            News = new HashSet<News>();
            Players = new HashSet<Player>();
            Results = new HashSet<Result>();
        }

        [Key]
        [Column("team_id")]
        public int TeamId { get; set; }
        [Column("team_name")]
        [StringLength(50)]
        public string TeamName { get; set; }
        [Column("team_match_played")]
        public int? TeamMatchPlayed { get; set; }
        [Column("team_won")]
        public int? TeamWon { get; set; }
        [Column("team_draw")]
        public int? TeamDraw { get; set; }
        [Column("team_lost")]
        public int? TeamLost { get; set; }
        [Column("team_goal_for")]
        public int? TeamGoalFor { get; set; }
        [Column("team_goal_ag")]
        public int? TeamGoalAg { get; set; }
        [Column("team_goal_on")]
        public int? TeamGoalOn { get; set; }
        [Column("league_id")]
        public int? LeagueId { get; set; }
        [Column("coach_id")]
        public int? CoachId { get; set; }
        [Column("team_image")]
        [StringLength(500)]
        public string TeamImage { get; set; }

        [ForeignKey(nameof(CoachId))]
        [InverseProperty("Teams")]
        public virtual Coach Coach { get; set; }
        [ForeignKey(nameof(LeagueId))]
        [InverseProperty("Teams")]
        public virtual League League { get; set; }
        [InverseProperty(nameof(Goal.Team))]
        public virtual ICollection<Goal> Goals { get; set; }
        [InverseProperty("Team")]
        public virtual ICollection<News> News { get; set; }
        [InverseProperty(nameof(Player.Team))]
        public virtual ICollection<Player> Players { get; set; }
        [InverseProperty(nameof(Result.Team))]
        public virtual ICollection<Result> Results { get; set; }
    }
}
