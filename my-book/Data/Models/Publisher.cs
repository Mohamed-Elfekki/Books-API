using System.Collections.Generic;

namespace my_book.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }



        // Navigation props which use to do the relationship with other Tables!
        // Here is One Publisher to Many Books !

        public List<Book> Books { get; set; }

    }
}
