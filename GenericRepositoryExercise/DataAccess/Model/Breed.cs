using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    internal class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
