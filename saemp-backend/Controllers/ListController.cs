using Microsoft.AspNetCore.Mvc;
using saemp_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace saemp_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController: ControllerBase
    {
        [HttpGet]
        [Route("TypeDocumentIdentity")]
        public ServiceResult TypeDocumentIdentity()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                result.data = context.PmTypeDocumentIdentities.FromSqlRaw("pmTypeDocumentIdentityList");
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }


        [HttpGet]
        [Route("Country")]
        public ServiceResult Country()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                result.data = context.PmCountries.FromSqlRaw("pmCountryList");
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }


        [HttpGet]
        [Route("Department")]
        public ServiceResult Department()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                result.data = context.PmDepartments.FromSqlRaw("pmDepartmentList");
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }


        [HttpGet]
        [Route("District")]
        public ServiceResult District()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                result.data = context.PmDistricts.FromSqlRaw("pmDistrictList");
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }
    }
}
