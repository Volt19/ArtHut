using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using ArtHut.Data.Models;
using ArtHut.Business.Services.Interfaces;

namespace ArtHut.Business.Services
{
	public class PhotosService : IPhotosService
	{
        private readonly IPhotosRepository _photoRepository;

        public PhotosService(IPhotosRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }
		public async Task<Photo> AddPhotoAsync(Photo photo) => await _photoRepository.AddAsync(photo);
        public async Task<IEnumerable<Photo>> AddRangeAsync(List<Photo> photos) => await _photoRepository.AddRangeAsync(photos);
        public async Task<Photo?> FindProductsMainPhotoAsync(int pruductId) => await _photoRepository.FindProductsMainPhotoAsync(pruductId);
        public async Task<List<Photo?>> GetProductsPhotosAsync(int pruductId) => await _photoRepository.FindProductsPhotosAsync(pruductId);
    }
}
