using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BannerStore.Models;
using MongoDB.Driver;
using BannerStore.Repositories;

namespace BannerStore.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private IMongoCollection<Banner> _banners;
        public BannerRepository(IMongoDatabase bannerstore)
        {
            if (bannerstore == null) throw new NullReferenceException("db is null");

            _banners = bannerstore.GetCollection<Banner>("banners");
        }


        public Banner Add(Banner entity)
        {
            _banners.InsertOne(entity);
            return entity;
        }

        public Banner Get(string id)
        {
           return _banners.Find(b => b.Id == id).Single();
        }

        public void Remove(string id)
        {
            _banners.DeleteOne(b => b.Id == id);
        }

        public void Edit(string id, Banner entity)
        {
            _banners.ReplaceOne(b=>b.Id == id, entity);
        }

        public IEnumerable<Banner> GetAll()
        {
            return _banners.Find(b => true).ToList();
        }
        
    }
}