using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public required string ISBN { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; }    

        public required int Copies { get; set; }
    }
}
