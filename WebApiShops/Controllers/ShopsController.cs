using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WebApiShops.Models;
using System.Web.Http;

namespace WebApiShops.Controllers
{
    [RoutePrefix("api/shops")]
    public class ShopsController : ApiController
    {
        private IShopsRepository _shopItems { get; set; }
        public ShopsController(IShopsRepository shopRepository)
        {
            _shopItems = shopRepository;
        }

        [HttpGet]
        [Route("")]
        public List<Shop> GetAll(int limit = 5, int offset = 0)
        {
            return _shopItems.GetAll(limit, offset);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var shop = _shopItems.Find(id);
                if (shop == null)
                {
                    return NotFound();
                }
                return Ok(shop);
            }
            catch (Exception ex)
            {
                return Ok("Error Find: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("~/api/owners/{owner:alpha?}")]
        public IHttpActionResult GetShopByOwner(string owner = null)
        {
            return Ok(_shopItems.GetShopByOwner(owner));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] Shop item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _shopItems.Add(item);
            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var shop = _shopItems.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            _shopItems.Remove(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult Update([FromBody] Shop item, int id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shop = _shopItems.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            item.Id = shop.Id;
            
            if (item.Name == shop.Name)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotModified));
            }

            _shopItems.Update(item);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}