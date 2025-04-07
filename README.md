Code Test

We would like you to refactor the GetLearner method in the LearnerService class. When refactoring you should consider the following; SOLID principles, maintainability, testing.
You can use any framework(s) of your choice. We are not expecting the work to be finished, we will expect you to discuss your approach and any further improvement you would make.
You can make any changes, apart from the following
•	Signature of the ArchivedDataService
•	Signature of the LearnerDataAccess
•	Signature of the FailoverLearnerDataAccess
The GetLearner method is responsible for executing the following logic
•	Based on the isLearnerArchived parameter retrieving Learners from the archive
•	The main Learner data store is a 3rd party service (which doesn’t have particularly high SLA), so therefore a failover data store has been created which stores a back up copy of the Learner  records
•	The method evaluates if the system should be in failover mode based on a given number of failed requests in a given time period (currently 10 minutes)
•	If the system is in failover mode Learners are retrieved from the failover store
The refactored solution must compile and should be accompanied by Unit Tests
