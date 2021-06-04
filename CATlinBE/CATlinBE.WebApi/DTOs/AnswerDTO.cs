using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.DTOs
{
    public class AnswerDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public long QuestionId { get; set; }
    }
}
