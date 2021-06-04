namespace CATlinBE.Entities
{
    public class Answer
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long IsCorrect { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
