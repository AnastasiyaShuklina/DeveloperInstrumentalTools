using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}