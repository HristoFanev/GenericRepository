using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Animal
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
        public string Description { get; set; }
        
        public int BreedId { get; set; }
        public Breed Breeds { get; set; }
    }
}
