using System.Linq;

namespace WhoWantsToBeAMillionaire.Models.Repositories
{
    public interface IAnswerRepository
    {
        IQueryable<Answer> Answers { get; }
    }
}
