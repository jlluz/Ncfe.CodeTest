namespace Ncfe.CodeTest
{
    public interface IArchivedDataService<T>
    {
        Learner GetArchivedLearner(int learnerId);
    }
}