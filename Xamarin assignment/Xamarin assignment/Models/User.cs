using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace Xamarin_assignment.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public string Sex { get; set; }
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
