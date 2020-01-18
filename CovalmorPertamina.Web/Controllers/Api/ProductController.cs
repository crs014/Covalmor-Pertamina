using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Web.Models.DataTable;
using CovalmorPertamina.Web.Requests;
using JQDT.WebAPI;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class ProductController : BaseApiController
    {
        public ProductController(IEntityFactory entityFactory)
        {
            _productRepository = entityFactory.Repositories(ERepository.Product) as IProductRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin, EUserRole.User })]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IEnumerable<Product> products = await Task.FromResult(_productRepository.GetAll());
                return new HttpJsonApiResult<IEnumerable<ProductModel>>(
                    ProductModel.GetAll(products), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("datatable")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        [JQDataTable]
        public async Task<IHttpActionResult> GetDataTable()
        {
            try
            {
                IQueryable<ProductDataTableModel> products = await Task.FromResult(_productRepository.GetAll()
                    .OrderByDescending(e => e.UpdatedAt)
                    .Select(e => new ProductDataTableModel() 
                    { 
                        Id = e.Id,
                        MaterialNo = e.MaterialNo,
                        MaterialName = e.MaterialName
                    }));
                return Ok(products);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Product product = await _productRepository.GetOne(id);
                if(product == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<ProductModel>(
                    new ProductModel(product), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Post([FromBody]ProductRequest data)
        {
            try
            {
                Product product = await _productRepository.Create(data.GetObject());
                return new HttpJsonApiResult<ProductModel>(
                    new ProductModel(product), Request, HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        [ActionName("Update")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Update(int id, [FromBody]ProductRequest data)
        {
            try
            {
                Product product = await _productRepository.Update(id, data.GetObject());
                if(product == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<ProductModel>(
                    new ProductModel(product), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Product product = await _productRepository.Delete(id);
                if(product == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<ProductModel>(
                    new ProductModel(product), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}