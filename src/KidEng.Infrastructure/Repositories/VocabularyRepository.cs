using KidEng.Application.Persistences;
using KidEng.Domain.Entities;
using KidEng.Infrastructure.Persistence;

namespace KidEng.Infrastructure.Repositories
{
    public class VocabularyRepository: RepositoryBase<Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(KidEngContext dbContext) : base(dbContext)
        {
        }
    }
}
