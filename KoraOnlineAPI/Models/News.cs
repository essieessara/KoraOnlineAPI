using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("news")]
    public partial class News
    {
        [Key]
        [Column("news_id")]
        public int NewsId { get; set; }
        [Column("news_title")]
        public string NewsTitle { get; set; }
        [Column("news_date", TypeName = "date")]
        public DateTime? NewsDate { get; set; }
        [Column("news_time")]
        public TimeSpan? NewsTime { get; set; }
        [Column("news_category_id")]
        public int? NewsCategoryId { get; set; }
        [Column("news_image")]
        public string NewsImage { get; set; }
        [Column("news_writer")]
        [StringLength(50)]
        public string NewsWriter { get; set; }
        [Column("news_description")]
        public string NewsDescription { get; set; }
        [Column("coach_id")]
        public int? CoachId { get; set; }
        [Column("league_id")]
        public int? LeagueId { get; set; }
        [Column("team_id")]
        public int? TeamId { get; set; }
        [Column("stad_id")]
        public int? StadId { get; set; }
        [Column("match_id")]
        public int? MatchId { get; set; }
        [Column("player_id")]
        public int? PlayerId { get; set; }

        [ForeignKey(nameof(LeagueId))]
        [InverseProperty("News")]
        public virtual League League { get; set; }
        [ForeignKey(nameof(MatchId))]
        [InverseProperty("News")]
        public virtual Match Match { get; set; }
        [ForeignKey(nameof(NewsCategoryId))]
        [InverseProperty(nameof(Category.News))]
        public virtual Category NewsCategory { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("News")]
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(StadId))]
        [InverseProperty(nameof(Stadium.News))]
        public virtual Stadium Stad { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("News")]
        public virtual Team Team { get; set; }
    }
}
