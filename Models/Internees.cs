using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SongsUI.Models
{
    public class Internees
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Goal Required")]
        public string Goal { get; set; }
    }

    public class InterneeDbContext: DbContext
    {
        public DbSet<Internees> intern { get; set; }
    }
}