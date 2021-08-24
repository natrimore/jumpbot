using System;

namespace jumpbot.Entities
{
    public class Order : BaseEntity
    {
        public Guid Number { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Status { get; set; }
    }
}
