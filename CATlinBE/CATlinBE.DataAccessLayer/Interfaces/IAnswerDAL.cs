﻿using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IAnswerDAL
    {
        List<Answer> GetAllAnswersFromQuestion(long questionId);
        List<Answer> GetAllAnswers();
        void InsertJSON(List<Answer> answers);
    }
}
