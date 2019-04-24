using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Onecore_Web.Models;

namespace Onecore_Web.Controllers
{
    public class EmployeeController : Controller
    {
        #region Actions Result

        [Route("Painel/Service/Employee")]
        public IActionResult Index()
        {
            //popula a table de employee
            var employees = GetAllEmployee();           

            return View("~/Views/Painel/Services/Employee.cshtml", employees);

        }
             
        public IActionResult Update(int Id)
        {
            // Pega id e monta o form para dar update no colaborador.
            var employees = GetEmployeeById(Id);

            PopulaEmissor();
            PopulaEmpresa();


            return View("~/Views/Page_Employee/Update.cshtml", employees);
        }

        public IActionResult PageCreate()
        {
            PopulaEmissor();
            PopulaEmpresa();

            return View("~/Views/Page_Employee/Create.cshtml");
        }

        public IActionResult Create(Employee employee)
        {
            string url = @"http://localhost:57593/api/employee";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(employee);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    employee = JsonConvert.DeserializeObject<Employee>(result);

                    if (employee != null)
                    {
                        PopulaEmissor();
                        PopulaEmpresa();
                        return View("~/Views/Page_Employee/Update.cshtml", employee);
                    }
                }

            }
            catch (Exception pEx)
            {

                throw pEx;
            }

            return View();
        }

        public IActionResult Delete(int Id)
        {
            string url = $@"http://localhost:57593/api/employee/{Id}";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "Delete";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var employees = GetAllEmployee();

                    return View("~/Views/Painel/Services/Employee.cshtml", employees);
                }

            }
            catch (Exception pEx)
            {

                throw pEx;
            }
            return Ok();
        }

        public IActionResult UpdateEmployee(int id, Employee employee)
        {

            string url = @"http://localhost:57593/api/employee";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(employee);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    employee = JsonConvert.DeserializeObject<Employee>(result);

                    if (employee != null)
                    {
                        PopulaEmissor();
                        PopulaEmpresa();
                        return View("~/Views/Page_Employee/Update.cshtml", employee);
                    }
                }

            }
            catch (Exception)
            {

                return BadRequest("erro");
            }

            return BadRequest();
        }

        #endregion

        #region Métodos 
        // Get all colaborador 
        public List<Employee> GetAllEmployee()
        {

            string url = $@"http://localhost:57593/api/employee/";


            List<Employee> employee = new List<Employee>();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string Json = reader.ReadToEnd();

                            employee = JsonConvert.DeserializeObject<List<Employee>>(Json);

                        }

                    }
                }
            }
            catch (Exception pEx)
            {

                throw pEx;
            }

            return employee;
        }
        // Get colaborador apenas pelo ID
        public Employee GetEmployeeById(int id)
        {

            string url = $@"http://localhost:57593/api/employee/{id}";


            Employee employee = new Employee();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string Json = reader.ReadToEnd();

                            employee = JsonConvert.DeserializeObject<Employee>(Json);

                        }

                    }
                }
            }
            catch (Exception pEx)
            {

                throw pEx;
            }

            return employee;
        }

        public List<Emissores> GetListEmiter()
        {
            List<Emissores> Emissor = new List<Emissores>();


            string url = $@"http://localhost:57593/api/emissor/";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string Json = reader.ReadToEnd();

                            Emissor = JsonConvert.DeserializeObject<List<Emissores>>(Json);

                        }

                    }
                }
            }
            catch (Exception pEx)
            {

                throw pEx;
            }

            return Emissor;
        }

        public List<Company> GetListCompany()
        {
            List<Company> Company = new List<Company>();


            string url = $@"http://localhost:57593/api/company/";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string Json = reader.ReadToEnd();

                            Company = JsonConvert.DeserializeObject<List<Company>>(Json);

                        }

                    }
                }
            }
            catch (Exception pEx)
            {

                throw pEx;
            }

            return Company;
        }

        public void PopulaEmissor()
        {
            var Model = GetListEmiter();

            List<SelectListItem> Emissor = (from i in Model.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Desc_Emissor,
                                                Value = i.EM_Id.ToString()

                                            }).ToList();

            ViewBag.Emissor = Emissor;
        }

        public void PopulaEmpresa()
        {
            var Model = GetListCompany();

            List<SelectListItem> Company = (from i in Model.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.CPY_NAME,
                                                Value = i.CPY_ID.ToString()

                                            }).ToList();

            ViewBag.Empresa = Company;
        }

        #endregion
    }
    
}