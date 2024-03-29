﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace CATlinBE.Entities
{
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public long ImageId { get; set; }
        public int TimeToAnswer { get; set; }
        public float Difficulty { get; set; }
        public string UniqueKey { get; set; }
        public long QuestionnaireId { get; set; }
        public long AdministratorId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
