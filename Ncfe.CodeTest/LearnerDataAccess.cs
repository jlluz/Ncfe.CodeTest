﻿namespace Ncfe.CodeTest
{
    public class LearnerDataAccess : ILearnerDataAccess<LearnerDataAccess>
    {
        public LearnerResponse LoadLearner(int learnerId)
        {
            // rettrieve learner from 3rd party webservice
            return new LearnerResponse();
        }
    }
}
