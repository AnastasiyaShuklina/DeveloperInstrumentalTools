using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Weather")]
    public class BookEntity
    {
        public int Id { get; set; }
        
        public AuthorEntity Author { get; set; }
        
        public DateTime TimeStamp { get; set; }
        
        public string Title { get; set; }
    }
}