﻿using System.ComponentModel.DataAnnotations;

namespace CATlinBE.WebApi.DTOs
{
    public class QuestionDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string UniqueKey { get; set; }
        public int TimeToAnswer { get; set; }
        public float Difficulty { get; set; }
        public long ImageId { get; set; }
    }
}
