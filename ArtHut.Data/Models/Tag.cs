using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtHut.Data.Models
{
    public class Tag
    {
        public Tag(string name)
        {
            Name=name;
            NormalizedName = name.ToUpper();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
