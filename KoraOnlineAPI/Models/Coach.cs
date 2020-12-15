using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("coach")]
    public partial class Coach
    {
        public Coach()
        {
            Teams = new HashSet<Team>();
        }

        [Key]
        [Column("coach_id")]
        public int CoachId { get; set; }
        [Column("coach_name")]
        [StringLength(50)]
        public string CoachName { get; set; }
        [Column("coach_image")]
        public string CoachImage { get; set; }

        [InverseProperty(nameof(Team.Coach))]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
