﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebApiModelBinding.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeEducationController : ControllerBase
    {
        private readonly ILogger<EmployeeEducationController> _logger;
        public EmployeeEducationController(ILogger<EmployeeEducationController> logger)
        {
            _logger = logger;
        }
        static List<EmployeeEducation> employeeEducations = new List<EmployeeEducation>();

        #region pass-parameters-using-uri
        [HttpPost]
        public ActionResult AddEmployeeEduFromUri([System.Web.Http.FromUri] int EmpEduId, [System.Web.Http.FromUri] string CourseName, [System.Web.Http.FromUri] string UniName, [System.Web.Http.FromUri] int MarksPercentage, [System.Web.Http.FromUri] int EmpId)
        {
            employeeEducations.Add(new EmployeeEducation { EmpEduId = EmpEduId, CourseName = CourseName, UniName = UniName, MarksPercentage = MarksPercentage, EmpId = EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            return Ok($"{serializedOp} added in the employeeEduList");
        }

        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromUri([System.Web.Http.FromUri] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.EmpId == EmpId).ToList();
            if (empEduList.Count > 0)
            {
                var serializedOp = JsonConvert.SerializeObject(empEduList);
                return Ok($"{serializedOp}");
            }
            else
            {
                return Ok($"EmpID: {EmpId} does not have any education details.");
            }


        }

        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromUri([System.Web.Http.FromUri] int EmpEduId, [System.Web.Http.FromUri] string CourseName, [System.Web.Http.FromUri] string UniName, [System.Web.Http.FromUri] int MarksPercentage, [System.Web.Http.FromUri] int EmpId)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = CourseName;
                emp.UniName = UniName;
                emp.MarksPercentage = MarksPercentage;
                emp.EmpId = EmpId;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }

        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromUri([System.Web.Http.FromUri] int EmpEduId, [System.Web.Http.FromUri] int updatedPercantage)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedPercantage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }

        [HttpDelete]
        public ActionResult DateteAEmployeeFromUri([System.Web.Http.FromUri] int EmpEduId)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.EmpEduId == EmpEduId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {EmpEduId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {EmpEduId} not found");
            }

        }
        #endregion

        #region pass-params-in-body

        [HttpPost]
        public ActionResult AddEmployeeEduFromBody([System.Web.Http.FromBody] EmployeeEducation employeeEducation)
        {
            employeeEducations.Add(new EmployeeEducation { EmpEduId = employeeEducation.EmpEduId, CourseName = employeeEducation.CourseName, UniName = employeeEducation.UniName, MarksPercentage = employeeEducation.MarksPercentage, EmpId = employeeEducation.EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            return Ok($"{serializedOp} added in the employeeEduList");
        }

        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromBody([System.Web.Http.FromBody] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.EmpId == EmpId).ToList();
            var serializedOp = JsonConvert.SerializeObject(empEduList);
            return Ok($"{serializedOp}");

        }

        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromBody([System.Web.Http.FromBody] EmployeeEducation employeeEducation)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == employeeEducation.EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = employeeEducation.CourseName;
                emp.UniName = employeeEducation.UniName;
                emp.MarksPercentage = employeeEducation.MarksPercentage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }

        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromBody([System.Web.Http.FromBody] int EmpEduId, [System.Web.Http.FromBody] int updatedPercantage)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedPercantage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }

        [HttpDelete]
        public ActionResult DateteAEmployeeFromBody([System.Web.Http.FromBody] int EmpEduId)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.EmpEduId == EmpEduId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {EmpEduId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {EmpEduId} not found");
            }
        }

        #endregion

        #region From Header
        [HttpPost]
        public ActionResult AddEmployeeEduFromHeader([FromHeader] int EmpEduId, [FromHeader] string CourseName, [FromHeader] string UniName, [FromHeader] int MarksPercentage, [FromHeader] int EmpId)
        {
            employeeEducations.Add(new EmployeeEducation { EmpEduId = EmpEduId, CourseName = CourseName, UniName = UniName, MarksPercentage = MarksPercentage, EmpId = EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            return Ok($"{serializedOp} added in the employeeEduList");
        }
        [HttpGet]
        public ActionResult GetEduListOfAEmployeeFromHeader([FromHeader] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.EmpId == EmpId).ToList();
            if (empEduList.Count > 0)
            {
                var serializedOp = JsonConvert.SerializeObject(empEduList);
                return Ok($"{serializedOp}");
            }
            else
            {
                return Ok($"EmpID: {EmpId} does not have any education details.");
            }


        }
        [HttpPut]
        public ActionResult UpdatedEmployeeEduDetailsFromHeader([FromHeader] int EmpEduId, [FromHeader] string CourseName, [FromHeader] string UniName, [FromHeader] int MarksPercentage, [FromHeader] int EmpId)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = CourseName;
                emp.UniName = UniName;
                emp.MarksPercentage = MarksPercentage;
                emp.EmpId = EmpId;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }
        [HttpDelete]
        public ActionResult DateteAEmployeeFromHeader([FromHeader] int EmpEduId)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.EmpEduId == EmpEduId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {EmpEduId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {EmpEduId} not found");
            }
        }
        [HttpPatch]
        public ActionResult UpdateOnlyMarksPercantageFieldFromHeader([FromHeader] int EmpEduId, [FromHeader] int updatedPercantage)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedPercantage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }
        #endregion

        #region From Route
        [HttpPost("{employeeEducation}")]
        public ActionResult AddEmployeeEduFromRoute([FromRoute] EmployeeEducation employeeEducation)
        {
            employeeEducations.Add(new EmployeeEducation { EmpEduId = employeeEducation.EmpEduId, CourseName = employeeEducation.CourseName, UniName = employeeEducation.UniName, MarksPercentage = employeeEducation.MarksPercentage, EmpId = employeeEducation.EmpId });
            var serializedOp = JsonConvert.SerializeObject(employeeEducations[employeeEducations.Count - 1]);
            return Ok($"{serializedOp} added in the employeeEduList");
        }

        [HttpGet("{EmpId}")]
        public ActionResult GetEduListOfAEmployeeFromRoute([FromRoute] int EmpId)
        {

            var empEduList = employeeEducations.Where(e => e.EmpId == EmpId).ToList();
            var serializedOp = JsonConvert.SerializeObject(empEduList);
            return Ok($"{serializedOp}");

        }

        [HttpPut("{employeeEducation}")]
        public ActionResult UpdatedEmployeeEduDetailsFromRoute([FromRoute] EmployeeEducation employeeEducation)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == employeeEducation.EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.CourseName = employeeEducation.CourseName;
                emp.UniName = employeeEducation.UniName;
                emp.MarksPercentage = employeeEducation.MarksPercentage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }


        }

        [HttpPatch("{EmpEduId}")]
        public ActionResult UpdateOnlyMarksPercantageFieldFromRoute([FromRoute] int EmpEduId, [FromRoute] int updatedPercantage)
        {
            var emp = employeeEducations.Where(emp => emp.EmpEduId == EmpEduId).FirstOrDefault();
            if (emp == null)
            {
                return Ok("EmployeeEducation id not found");
            }
            else
            {
                emp.MarksPercentage = updatedPercantage;
                var serializedOp = JsonConvert.SerializeObject(emp);
                return Ok($"{serializedOp} updated");
            }
        }



        [HttpDelete("{EmpEduId}")]
        public ActionResult DateteAEmployeeFromRoute([FromRoute] int EmpEduId)
        {
            var deleteEmployee = employeeEducations.Where(obj => obj.EmpEduId == EmpEduId).FirstOrDefault();
            if (deleteEmployee != null)
            {
                employeeEducations.Remove(deleteEmployee);

                return Ok($"EmpId: {EmpEduId} removed from employee edu list.");
            }
            else
            {
                return Ok($"EmpId: {EmpEduId} not found");
            }
        }
        #endregion
    }

}
