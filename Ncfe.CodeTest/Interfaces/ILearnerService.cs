namespace Ncfe.CodeTest
{
    public interface ILearnerService<T>
    {
        Learner GetLearner(int learnerId, bool isLearnerArchived);
    }
}