using AutoMapper;
using KidEng.Application.Models;
using KidEng.Application.Persistences;
using KidEng.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidEng.Application.Services
{
    public class VocabularyService : IVocabularyService
    {
        private readonly IVocabularyRepository _repo;
        private readonly IMapper _mapper;

        public VocabularyService(IVocabularyRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<VocabularyModel>> GetAll()
        {
            var lstVob = await _repo.GetAllAsync();
            return _mapper.Map<List<VocabularyModel>>(lstVob);
        }

        public async Task<VocabularyModel> GetById(int id)
        {
            var vob = await _repo.GetByIdAsync(id);
            if(vob != null)
                return _mapper.Map<VocabularyModel>(vob);
            return null;
        }

        public async Task<int> Add(VocabularyModel model)
        {
            var vob = _mapper.Map<Vocabulary>(model);
            var vobAdded = await _repo.AddAsync(vob);
            if(vobAdded != null)
                return vobAdded.Id;
            return 0;
        }

        public async Task Delete(int id)
        {
            var vobToDelete = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(vobToDelete);
        }

        public async Task Update(VocabularyModel model)
        {
            var vobToUpdate = _mapper.Map<Vocabulary>(model);
            await _repo.UpdateAsync(vobToUpdate);
        }
    }
}
