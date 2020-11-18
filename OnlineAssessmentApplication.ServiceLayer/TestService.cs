using AutoMapper;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using OnlineAssessmentApplication.ViewModel;
using System.Collections.Generic;

namespace OnlineAssessmentApplication.ServiceLayer
{
    public interface ITestService
    {
        TestViewModel GetTestByTestId(int testId);
        IEnumerable<TestViewModel> DisplayAllDetails();
        void CreateNewTest(CreateTestViewModel testViewModel);
        void UpdateTest(EditTestViewModel editedData);
        void DeleteTest(int testId);
    }
    public class TestService : ITestService
    {
        readonly ITestRepository testRepository;
        public TestService(ITestRepository testRepository)
        {
           this.testRepository = testRepository;
        }
        public void CreateNewTest(CreateTestViewModel testViewModel)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CreateTestViewModel, Test>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            var test = mapper.Map<CreateTestViewModel, Test>(testViewModel);
            testRepository.CreateNewTest(test);

        }
        public IEnumerable<TestViewModel> DisplayAllDetails()
        {
            IEnumerable<Test> test = testRepository.DisplayAllDetails();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Test, TestViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            IEnumerable<TestViewModel> allTests = mapper.Map<IEnumerable<Test>, IEnumerable<TestViewModel>>(test);
            return allTests;
        }
        public void UpdateTest(EditTestViewModel editedData)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditTestViewModel, Test>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Test editTest = mapper.Map<EditTestViewModel, Test>(editedData);
            testRepository.UpdateTest(editTest);
        }
        public void DeleteTest(int testId)
        {
            testRepository.DeleteTest(testId);
        }
        public TestViewModel GetTestByTestId(int testId)
        {
            Test test = testRepository.GetTestByTestId(testId);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Test, TestViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            TestViewModel OriginalData = mapper.Map<Test, TestViewModel>(test);
            return OriginalData;
        }

    }
}
