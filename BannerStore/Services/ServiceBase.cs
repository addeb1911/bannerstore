using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerStore.Services
{
    public class ServiceBase
    {
        public IMongoDatabase GetDB()
        {
            String uri = "mongodb://bannerministrator:banners4life@ds036069.mlab.com:36069/bannerstore";
            var client = new MongoClient(uri);
            var db = client.GetDatabase("bannerstore");
            
            return db;
        }
    }
}