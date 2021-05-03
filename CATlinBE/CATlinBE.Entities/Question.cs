namespace CATlinBE.Entities
{
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public long QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public int TimeToAnswer { get; set; }
        public float Difficulty { get; set; }
    }
}
