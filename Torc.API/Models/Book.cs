using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torc.API
{
    public class Book
    {
        [Column("book_id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("total_copies")]
        public int TotalCopies { get; set; }

        [Column("copies_in_use")]
        public int CopiesInUse { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("isbn")]
        public string Isbn { get; set; }

        [Column("category")]
        public string Category { get; set; }
    }
}
