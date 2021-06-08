using System;

namespace CATlinBE.Entities
{
    public class Session
    {
        public long Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public long SupervisorId { get; set; }
        public User Supervisor { get; set; }
        public long QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public string AccessKey { get; set; }
    }
}
