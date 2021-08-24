namespace jumpbot.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
