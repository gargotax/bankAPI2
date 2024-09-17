namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get;}
        public string Name { get; private set; }
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
