namespace SharedObjects.Accounts
{
    public class User
    {
        public User(int id, string email)
        {
            ID = id;
            Email = email;
        }

        public User(int id, string email, string firstname, string lastname) : this(id, email)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
        }
        public User() { }

        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
