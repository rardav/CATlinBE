using System.Collections.Generic;

namespace CATlinBE.Entities
{
    public class Questionnaire
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string URLTitle { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}
