using BannerStore.Models;
using BannerStore.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BannerStore.Services
{
    public class BannerService : ServiceBase
    {
        private BannerRepository _repo;

        public BannerService()
        {
            var db = GetDB();
            _repo = new BannerRepository(GetDB());
        }

        public void AddBanner(string html)
        {
            var banner = new Banner();
            banner.Html = html;
            var dateTimeStamp = DateTime.UtcNow;
            banner.Modified = dateTimeStamp;
            banner.Created = dateTimeStamp;
            _repo.Add(banner);
        }

        public void RemoveBanner(string id)
        {
            _repo.Remove(id);
        }

        public void UpdateBanner(string id, string html)
        {
            var banner = _repo.Get(id);
            banner.Html = html;
            banner.Modified = DateTime.UtcNow;
            _repo.Edit(id, banner);
        }

        public IEnumerable<Banner> GetAllBanners()
        {
            return _repo.GetAll();
        }

        public Banner GetBanner(string id)
        {
            return _repo.Get(id);
        }
    }
}