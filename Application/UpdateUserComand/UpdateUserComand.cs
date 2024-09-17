namespace Application.UpdateUserComand
{
    public class UpdateUserComand
    {
        public Guid Id { get;}
        public string Name { get;}
        public UpdateUserComand(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }
}