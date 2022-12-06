using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace Xamarin_assignment.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(1)]
        public string Sex { get; set; }
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        //public byte Picture { get; set; }
    }
}
