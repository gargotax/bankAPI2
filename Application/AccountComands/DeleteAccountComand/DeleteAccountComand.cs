namespace Application.AccountComands.DeleteAccountComand
{
    public class DeleteAccountComand
    {
        public Guid AccountId { get; set; }
        public DeleteAccountComand(Guid id)
        {
            AccountId = id;
        }
    }
}
