using BannerStore.Models;
using BannerStore.Services;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BannerStore.Controllers
{
    public class BannerController : ApiController
    {
        BannerService _bannerService;

        public BannerController()
        {
            _bannerService = new BannerService();
        }



        /// <summary>
        /// Get all banners
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<Banner>))]
        public IHttpActionResult Get()
        {
            var banners  = _bannerService.GetAllBanners();
            return Ok(banners);
        }

        /// <summary>
        /// Get a banner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Banner))]
        [Route("banner/{id}")]
        public IHttpActionResult Get(string id)
        {
            var banner = _bannerService.GetBanner(id);
            return Ok(banner);
        }


        /// <summary>
        /// Create a banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public IHttpActionResult Post(BannerModel model)
        {
            ValidateHtml(model.Html);
            _bannerService.AddBanner(model.Html);
            return Ok();
        }

        /// <summary>
        /// Remove a Banner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            _bannerService.RemoveBanner(id);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="banner"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(string id, BannerModel model)
        {
            ValidateHtml(model.Html);
            _bannerService.UpdateBanner(id, model.Html);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(string))]
        [HttpGet]
        [Route("BannerHtml")]
        public IHttpActionResult GetHtml(string id)
        {
            var banner = _bannerService.GetBanner(id);
            return Ok(banner.Html);
        }

        private bool ValidateHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            if (doc.ParseErrors.Count() > 0)
            {

                var errorMessage = string.Join(",",doc.ParseErrors
                    .Select(q=> q.Reason));
                throw new FormatException(errorMessage);
            }
            return true;
        }

    }
}
