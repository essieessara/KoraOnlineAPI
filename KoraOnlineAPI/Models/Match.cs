using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("match")]
    public partial class Match
    {
        public Match()
        {
            Goals = new HashSet<Goal>();
            News = new HashSet<News>();
            Results = new HashSet<Result>();
        }

        [Key]
        [Column("match_id")]
        public int MatchId { get; set; }
        [Column("match_date", TypeName = "date")]
        public DateTime? MatchDate { get; set; }
        [Column("match_time")]
        public TimeSpan? MatchTime { get; set; }
        [Column("match_status")]
        [StringLength(50)]
        public string MatchStatus { get; set; }
        [Column("staduim_id")]
        public int? StaduimId { get; set; }
        [Column("league_id")]
        public int? LeagueId { get; set; }
        [Column("match_team_name1")]
        [StringLength(50)]
        public string MatchTeamName1 { get; set; }
        [Column("match_team_name2")]
        [StringLength(50)]
        public string MatchTeamName2 { get; set; }
        [Column("match_week")]
        [StringLength(50)]
        public string MatchWeek { get; set; }
        [Column("match_team_result1")]
        [StringLength(50)]
        public string MatchTeamResult1 { get; set; }
        [Column("match_team_result2")]
        [StringLength(50)]
        public string MatchTeamResult2 { get; set; }

        [ForeignKey(nameof(LeagueId))]
        [InverseProperty("Matches")]
        public virtual League League { get; set; }
        [ForeignKey(nameof(StaduimId))]
        [InverseProperty(nameof(Stadium.Matches))]
        public virtual Stadium Staduim { get; set; }
        [InverseProperty(nameof(Goal.Match))]
        public virtual ICollection<Goal> Goals { get; set; }
        [InverseProperty("Match")]
        public virtual ICollection<News> News { get; set; }
        [InverseProperty(nameof(Result.Match))]
        public virtual ICollection<Result> Results { get; set; }
    }
}
