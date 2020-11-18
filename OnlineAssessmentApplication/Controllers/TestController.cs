using OnlineAssessmentApplication.ServiceLayer;
using OnlineAssessmentApplication.ViewModel;
using System;
using System.Web.Mvc;

namespace OnlineAssessmentApplication.Controllers
{
    public class TestController : Controller
    {
        readonly ITestService testService;
        public TestController(ITestService testService)
        {
            this.testService = testService;
        }
        // GET: Test
        public ActionResult CreateTest()
        {

            return View();
        }
        [HttpPost]
        [ActionName("CreateTest")]
        public ActionResult SaveTest(CreateTestViewModel newTest)//Create Test
        {

            if (ModelState.IsValid)
            {
                newTest.UserId = Convert.ToInt32(Session["CurrentUserID"]);
                newTest.CreatedBy = newTest.UserId;
                newTest.CreatedTime = DateTime.Now;


                testService.CreateNewTest(newTest);
                return RedirectToAction("DisplayAvailableTest");
            }
            return View();
        }
        public ActionResult EditTest(int testId)
        {

            TestViewModel test = testService.GetTestByTestId(testId);
            return View(test);
        }
        [HttpPost]
        public ActionResult EditTest(EditTestViewModel editedData)
        {
            if (ModelState.IsValid)
            {
                editedData.ModifiedBy = Convert.ToInt32(Session["CurrentUserID"]);
                editedData.ModifiedTime = DateTime.Now;
                testService.UpdateTest(editedData);
                return RedirectToAction("DisplayAvailableTest");
            }
            return View();

        }
        public ActionResult DeleteTest(int testId)
        {

            testService.DeleteTest(testId);
            return RedirectToAction("DisplayAvailableTest");
        }
    }
}