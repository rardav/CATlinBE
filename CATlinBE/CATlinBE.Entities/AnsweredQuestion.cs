namespace CATlinBE.Entities
{
    public class AnsweredQuestion
    {
        public long Id { get; set; }
        public int AnsweredCorrectly { get; set; }
        public int NumberOfOrder { get; set; }

        public long IndividualSessionId { get; set; }
        public IndividualSession IndividualSession { get; set; }
        public float QuestionDifficulty { get; set; }
    }
}
