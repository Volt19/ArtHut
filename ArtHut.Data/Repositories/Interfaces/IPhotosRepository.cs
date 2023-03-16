using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHut.Data.Repositories.Interfaces
{
	public interface IPhotosRepository:IRepository<Photo>
	{
		Task<List<Photo?>> FindProductsPhotosAsync(int productId);
		Task<Photo?> FindProductsMainPhotoAsync(int productId);
	}
}
