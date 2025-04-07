using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    public class LearnerService : ILearnerService<LearnerService>
    {
        private readonly IArchivedDataService<ArchivedDataService> _archivedDataService;
        private readonly IFailoverRepository<FailoverRepository> _failoverRepository;
        private readonly ILearnerDataAccess<LearnerDataAccess> _learnerDataAccess;
        private int _failedRequestsTreshold;
        private double _minutesToAdd;
        public bool _isLearnerArchived { get; set; }

        public LearnerService(IArchivedDataService<ArchivedDataService> archivedDataService, 
                IFailoverRepository<FailoverRepository> failoverRepository,
                ILearnerDataAccess<LearnerDataAccess> learnerDataAccess)
        {
            _archivedDataService = archivedDataService;
            _failoverRepository = failoverRepository;
            _learnerDataAccess = learnerDataAccess;

            _failedRequestsTreshold = 100;
            _minutesToAdd = -10;
        }

        public Learner GetLearner(int learnerId, bool isLearnerArchived)
        {
            Learner archivedLearner = null;

            if (isLearnerArchived)
            {
                archivedLearner = _archivedDataService.GetArchivedLearner(learnerId);

                return archivedLearner;
            }
            else
            {
                var failoverEntries = _failoverRepository.GetFailOverEntries();

                var failedRequests = 0;

                foreach (var failoverEntry in failoverEntries)
                {
                    if (failoverEntry.DateTime > DateTime.Now.AddMinutes(_minutesToAdd))
                    {
                        failedRequests++;
                    }
                }

                LearnerResponse learnerResponse = null;
                Learner learner = null;

                if (failedRequests > _failedRequestsTreshold && (ConfigurationManager.AppSettings["IsFailoverModeEnabled"].ToLower() == "true"))
                {
                    learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
                }
                else
                {
                    learnerResponse = _learnerDataAccess.LoadLearner(learnerId);


                }

                if (learnerResponse.IsArchived)
                {
                    learner = _archivedDataService.GetArchivedLearner(learnerId);
                }
                else
                {
                    learner = learnerResponse.Learner;
                }


                return learner;
            }
        }
    }
}
