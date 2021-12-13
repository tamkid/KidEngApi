using KidEng.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidEng.Application.Services
{
    public interface IVocabularyService
    {
        public Task<List<VocabularyModel>> GetAll();
        public Task<VocabularyModel> GetById(int id);
        public Task<int> Add(VocabularyModel model);
        public Task Update(VocabularyModel model);
        public Task Delete(int id);
    }
}
