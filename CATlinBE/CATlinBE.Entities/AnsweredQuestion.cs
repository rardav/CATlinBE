namespace CATlinBE.Entities
{
    public class AnsweredQuestion
    {
        public long Id { get; set; }
        public long IndividualSessionId { get; set; }
        public IndividualSession IndividualSession { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }
        public bool HasAnsweredCorrectly { get; set; }
        public int NumberOfOrder { get; set; }
    }
}
