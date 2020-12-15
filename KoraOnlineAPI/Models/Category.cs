using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KoraOnlineAPI.Models
{
    [Table("category")]
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        [Key]
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [Column("Category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty("NewsCategory")]
        public virtual ICollection<News> News { get; set; }
    }
}
