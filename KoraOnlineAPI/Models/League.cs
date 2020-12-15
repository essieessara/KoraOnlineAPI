using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("league")]
    public partial class League
    {
        public League()
        {
            Matches = new HashSet<Match>();
            News = new HashSet<News>();
            Teams = new HashSet<Team>();
        }

        [Key]
        [Column("league_id")]
        public int LeagueId { get; set; }
        [Column("league_name")]
        [StringLength(50)]
        public string LeagueName { get; set; }
        [Column("league_image")]
        public string LeagueImage { get; set; }

        [InverseProperty(nameof(Match.League))]
        public virtual ICollection<Match> Matches { get; set; }
        [InverseProperty("League")]
        public virtual ICollection<News> News { get; set; }
        [InverseProperty(nameof(Team.League))]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
