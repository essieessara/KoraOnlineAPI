using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("city")]
    public partial class City
    {
        public City()
        {
            Stadia = new HashSet<Stadium>();
        }

        [Key]
        [Column("city_id")]
        public int CityId { get; set; }
        [Column("city_name")]
        [StringLength(50)]
        public string CityName { get; set; }
        [Column("country_id")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }
        [InverseProperty(nameof(Stadium.City))]
        public virtual ICollection<Stadium> Stadia { get; set; }
    }
}
