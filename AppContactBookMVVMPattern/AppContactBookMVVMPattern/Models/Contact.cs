using SQLite;
using System.Collections.Generic;

namespace AppContactBookMVVMPattern.Models
{
    public class Contact
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
