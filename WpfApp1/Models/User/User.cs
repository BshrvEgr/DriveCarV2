using System;

namespace WpfApp1.Models.User
{
    public class User
    {
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string PassportId { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string DateBirthday { get; set; }

        public string FullName { get { return $"{Firstname} {MiddleName} {LastName}"; } }
    }
}
