using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheContactsApp.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
    }
}
