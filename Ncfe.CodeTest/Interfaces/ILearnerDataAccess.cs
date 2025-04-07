namespace Ncfe.CodeTest
{
    public interface ILearnerDataAccess<T>
    {
        LearnerResponse LoadLearner(int learnerId);
    }
}