using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using saemp_backend.Models;
using saemp_backend.DBContext;
using saemp_backend.DBContext.Models;
using Microsoft.Data.SqlClient;

namespace saemp_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonListController: ControllerBase
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
        [Route("Province")]
        public ServiceResult Province(int idDepartment)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@pIdDepartment", idDepartment)
                };
                result.data = context.PmProvinces.FromSqlRaw("exec pmProvinceList {0}", parameters);
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }


        [HttpGet]
        [Route("District")]
        public ServiceResult District(int idDepartment, int idProvince)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DBSaempContext context = new DBSaempContext();
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@pIdDepartment", idDepartment),
                    new SqlParameter("@pIdProvince", idProvince)
                };
                result.data = context.PmDistricts.FromSqlRaw("exec pmDistrictList {0}, {1}", parameters);
            }
            catch (Exception ex)
            {
                result.setMessage(ex.Message);
            }
            return result;
        }
    }
}
