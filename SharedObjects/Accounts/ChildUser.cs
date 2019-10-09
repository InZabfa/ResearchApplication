namespace SharedObjects.Accounts
{
    public class ChildUser
    {
        public ChildUser(int id, string email)
        {
            ID = id;
            Email = email;
        }

        public ChildUser(int id, string email, string parentname, string childFirstName, string lastname) : this(id, email)
        {
            Email = email;
            ParentName = parentname;
            ChildName = childFirstName;
            LastName = lastname;
        }

        public ChildUser() { }

        public int ID { get; set; }
        public string Email { get; set; }
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public string LastName { get; set; }
    }
}
