using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace my_book.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }


        //Navigation props!
        public List<Book_Author> Book_Authors { get; set; }
    }
}
