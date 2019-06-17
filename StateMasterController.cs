using APITestNew.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APITestNew.Controllers
{
    public class StateMasterController : ApiController
    {

        [System.Web.Http.Route("api/abc")]

        public IHttpActionResult Post([FromBody]STATEMASTER STATEMASTER)
        {
            string result = "";

             //   DateTime date = DateTime.Now;
          
             // STATEMASTER.DOB=date;
               SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
                SqlCommand cmd = new SqlCommand("GetBooks1", con);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@@tno", STATEMASTER.TNO);
            cmd.Parameters.AddWithValue("@EmployeeName", STATEMASTER.EmployeeName);
            cmd.Parameters.AddWithValue("@date", STATEMASTER.DOB).ToString();
            cmd.Parameters.AddWithValue("@Department", STATEMASTER.Department);
            cmd.Parameters.AddWithValue("@ReportingManger", STATEMASTER.ReportingManger);
            cmd.Parameters.AddWithValue("@IamnotaRobort", STATEMASTER.IamnotaRobort);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {

                result = "New Employee Added Successfully";
               return Ok(result);

            }
            else
            {
               return NotFound();

            }
        }

        //[HttpGet]
        //[System.Web.Http.Route("api/abc")]
        //public IHttpActionResult AddEmployees(STATEMASTER STATEMASTER)
        //{
        //    //calling EmpRepository Class Method and storing Repsonse 
        //    string result = "";
        //    // DateTime date = DateTime.Now;

        //    DateTime date = DateTime.Now;
        ////    date = statedata.DOB;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["USPL_FINANCEEntities"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("GetBooks1", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //  //  cmd.Parameters.AddWithValue("@EmployeeName", statedata.EmployeeName);
        //  //  cmd.Parameters.AddWithValue("@DOB", date);
        //  //  cmd.Parameters.AddWithValue("@Department", statedata.Department);
        //  //  cmd.Parameters.AddWithValue("@ReportingManger", statedata.ReportingManger);
        //   // cmd.Parameters.AddWithValue("@IamnotaRobort", statedata.IamnotaRobort);
        //    con.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    //  int i = com.ExecuteNonQuery();
        //    //con.Close();

        //    if (i >= 1)
        //    {

        //        result = "New Employee Added Successfully";
        //        return  Ok(result);

        //    }
        //    else
        //    {
        //        return NotFound();

        //    }


        //    //var response = repository.AddEmployees(Emp);
        //    //return result;

        //}

    }

}
