﻿using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IQuestionnaireDAL
    {
        List<Questionnaire> GetAllQuestionnaires();
        Questionnaire GetQuestionnaireByURLTitle(string title);
        Questionnaire GetQuestionnaireById(long id);
        long GetQuestionnaireIdByURLTitle(string title);
    }
}
