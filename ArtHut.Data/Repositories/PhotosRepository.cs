﻿using ArtHut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtHut.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtHut.Data.Repositories
{
	public class PhotosRepository : Repository<Photo>, IPhotosRepository
    {
        protected ArtHutDbContext Context { get; set; }
        protected DbSet<Photo> PhotoEntities { get; set; }
        public PhotosRepository(ArtHutDbContext context) : base(context)
        {
            Context = context;
            PhotoEntities = Context.Set<Photo>();
        }
        public async Task<List<Photo?>> FindProductsPhotosAsync(int productId)
        {
            return PhotoEntities.Where(x=> x.ProductId==productId).ToList();
        }
        public async Task<Photo?> FindProductsMainPhotoAsync(int productId)
        {
            return PhotoEntities.Where(x => x.ProductId==productId&& x.IsMain).Single();
        }

    }
}
