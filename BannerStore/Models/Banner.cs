using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BannerStore.Models
{
    public class Banner
    {
        public Banner()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Html { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}