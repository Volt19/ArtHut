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
	}
}
