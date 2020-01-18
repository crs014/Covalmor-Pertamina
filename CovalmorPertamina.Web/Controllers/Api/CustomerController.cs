using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Requests;
using CovalmorPertamina.Entity;
using JQDT.WebAPI;
using CovalmorPertamina.Web.Models.DataTable;
using System.Linq;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class CustomerController : BaseApiController
    {
        public CustomerController(IEntityFactory entityFactory)
        {
            _customerRepository = entityFactory.Repositories(ERepository.Customer) as ICustomerRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin, EUserRole.User })]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IQueryable<Customer> customers = await Task.FromResult(_customerRepository.GetAll());
                return new HttpJsonApiResult<IEnumerable<CustomerModel>>(
                    CustomerModel.GetAll(customers), Request, HttpStatusCode.OK);
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
                IQueryable<CustomerDataTableModel> customers = await Task.FromResult(_customerRepository.GetAll()
                    .OrderByDescending(e => e.UpdatedAt)
                    .Select(e => new CustomerDataTableModel() 
                    {
                        Id = e.Id,
                        CustomerNo = e.CustomerNo,
                        Name = e.Name,
                        Address = e.Address,
                        Email = e.Email,
                        NPWP = e.NPWP
    }               ));
                return Ok(customers);
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
                Customer customer = await _customerRepository.GetOne(id);
                if(customer == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerModel>(
                    new CustomerModel(customer), Request, HttpStatusCode.OK);
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
        public async Task<IHttpActionResult> Post([FromBody]CustomerRequest data)
        {
            try
            {
                Customer customer = await _customerRepository.Create(data.GetObject());
                return new HttpJsonApiResult<CustomerModel>(
                    new CustomerModel(customer), Request, HttpStatusCode.Created);
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
        public async Task<IHttpActionResult> Update(int id, [FromBody]CustomerRequest data)
        {
            try
            {
                Customer customer = await _customerRepository.Update(id, data.GetObject());
                if(customer == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerModel>(
                    new CustomerModel(customer), Request, HttpStatusCode.OK);
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
                Customer customer = await _customerRepository.Delete(id);
                if(customer == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerModel>(
                    new CustomerModel(customer), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}