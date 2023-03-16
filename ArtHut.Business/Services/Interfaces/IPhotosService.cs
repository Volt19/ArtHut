using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Business.Services.Interfaces
{
	public interface IPhotosService
	{
		Task<Photo> AddPhotoAsync(Photo photo);
		Task<Photo?> FindProductsMainPhotoAsync(int pruductId);
		Task<List<Photo?>> GetProductsPhotosAsync(int pruductId);
	}
}
