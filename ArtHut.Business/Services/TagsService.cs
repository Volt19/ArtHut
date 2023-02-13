using ArtHut.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using ArtHut.Data.Models;

namespace ArtHut.Business.Services
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }
        public async Task AddTagAsync(Tag tag) => await _tagsRepository.AddAsync(tag);
    }
}
