using AutoMapper;
using KidEng.Application.Models;
using KidEng.Domain.Entities;

namespace KidEng.Application.Mappings
{
    public class VocabularyProfile: Profile
    {
        public VocabularyProfile()
        {
            CreateMap<VocabularyModel, Vocabulary>().ReverseMap();
        }
    }
}
