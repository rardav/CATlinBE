using System;

namespace CATlinBE.Entities
{
    public class IndividualSession
    {
        public long Id { get; set; }
        public float Ability { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ExamineeId { get; set; }
        public User Examinee { get; set; }
        public long SessionId { get; set; }
        public Session Session { get; set; }
    }
}
