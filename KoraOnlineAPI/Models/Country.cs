using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("country_abbrevation")]
        [StringLength(50)]
        public string CountryAbbrevation { get; set; }
        [Column("country_name")]
        [StringLength(50)]
        public string CountryName { get; set; }

        [InverseProperty(nameof(City.Country))]
        public virtual ICollection<City> Cities { get; set; }
    }
}
