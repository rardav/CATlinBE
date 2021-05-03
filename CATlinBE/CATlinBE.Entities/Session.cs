using System;

namespace CATlinBE.Entities
{
    public class Session
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long SupervisorId { get; set; }
        public User Supervisor { get; set; }
        public long QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
