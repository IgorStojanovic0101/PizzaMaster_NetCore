
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;
using PizzaMaster.WebAPI.Controllers;
using PizzaMaster.Application.Services;
using PizzaMaster.Shared.DTOs.Home.HomeDescription;
using PizzaMaster.Shared.Results;

namespace MSTest
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<IHomeService> _service;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new Mock<IHomeService>();
            _controller = new HomeController(_service.Object);
        }
		
		  // [TestMethod]
        // public void TestMethod1()
        // {
            // var expectedResponse = new ServiceResponse<Document_ResponseDTO>
            // {
                // Errors = new List<string>(),
                // Success = true,
                // Payload = new Document_ResponseDTO
                // {
                    // company = new Company_ResponseDTO
                    // {
                        // RegistrationNumber = "019019019",
                        // CompanyType = "large"
                    // },
                    // data = JObject.Parse(@"
                    // {
                      // ""account_number"": ""cea00b23d30f77f27b1ddbcb89b25fb13dbea652a5f6fb6fe9a6bac4ddc5fb0d"",
                      // ""balance"": 42331.12,
                      // ""currency"": ""#####"",
                      // ""transactions"": [
                        // {
                          // ""transaction_id"": ""05b68f8f80d45137ec15579cdf91c560b0acaf4ad71a7d5a5352bcee36a3bb81"",
                          // ""amount"": ""#####"",
                          // ""date"": ""#####"",
                          // ""description"": ""#####"",
                          // ""category"": ""#####""
                        // },
                        // {
                          // ""transaction_id"": ""af8637ccf1fe693c254b44327672cf7589e3c8556de8ccceffd368c2f313e2ee"",
                          // ""amount"": ""#####"",
                          // ""date"": ""#####"",
                          // ""description"": ""#####"",
                          // ""category"": ""#####""
                        // },
                        // {
                          // ""transaction_id"": ""a183251a8414fd819da06488541d523365d51a7d0d942e272c2dce108f6dcdae"",
                          // ""amount"": ""#####"",
                          // ""date"": ""#####"",
                          // ""description"": ""#####"",
                          // ""category"": ""#####""
                        // }
                      // ]
                    // }")
                // }
            // };

            // var request = new Document_RequestDTO() { DocumentId = Guid.NewGuid(), ProductCode = "ProductA", TenantId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6") };

            // _service.Setup(uow => uow.GetTaxResponse(request)).Returns(expectedResponse);


            // var actionResult = _controller.FinancialRequest(request);


            // var result = actionResult.Result as OkObjectResult;
            // Assert.IsInstanceOfType(result, typeof(OkObjectResult));


            // var serizalizedExpectedResponse = JsonConvert.SerializeObject(expectedResponse.Payload,Formatting.Indented);
            // var serizalizedActualResponse = result.Value.ToString();

            // Assert.AreEqual(serizalizedExpectedResponse, serizalizedActualResponse);


        // }

        [TestMethod]
        public async Task Index_ReturnsViewWithListOfGlossaryModels()
        {
            var expectedResponse = new ServiceResponse<List<HomeDescription_ResponseDTO>>
            {
                Errors = new List<string>(),
                Validation = false,
                Payload = new List<HomeDescription_ResponseDTO>
                {
                    // Add your expected DTOs here for testing
                }
                
            };

            _service.Setup(uow => uow.GetHomeDescription())
            .Returns(expectedResponse.Payload);

            var response = _controller.GetHomeDescription();

            Assert.IsInstanceOfType(response, typeof(ActionResult<ServiceResponse<List<HomeDescription_ResponseDTO>>>));

            var payload = response.Value.Payload;

            // Use appropriate assertion methods based on your expectations
            CollectionAssert.AreEqual(expectedResponse.Payload, payload);
        }

        //[TestMethod]
        //public async Task Details_WithValidId_ReturnsViewWithGlossaryModel()
        //{
        //    // Arrange
        //    var glossaryId = 4;
        //    var glossaryModel = new GlossaryModel { Id = glossaryId, Term = "Bla 123" };
        //    _unitOfWorkMock.Setup(uow => uow.Glossary.GetFirstOrDefault(
        //     It.IsAny<Expression<Func<GlossaryModel, bool>>>(), null))
        //    .Returns(glossaryModel);

        //    var result = await _controller.Details(glossaryId);

        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    var viewResult = (ViewResult)result;
        //    var model = (GlossaryModel)viewResult.Model;
        //    Assert.AreEqual(glossaryId, model.Id);
        //}

        //[TestMethod]
        //public async Task Details_WithNullId_ReturnsNotFoundResult()
        //{

        //    var result = await _controller.Details(null);

        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        //[TestMethod]
        //public async Task Create_WithExistingTerm_ReturnsViewResult()
        //{
        //    var glossaryModel = new GlossaryModel { Term = "dsad" };

        //    _unitOfWorkMock.Setup(uow => uow.Glossary.Any(x => x.Term == glossaryModel.Term))
        //        .Returns(true);



        //    var result = await _controller.Create(glossaryModel);

        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    var viewResult = (ViewResult)result;
        //    var model = (GlossaryModel)viewResult.Model;
        //    Assert.AreEqual(glossaryModel, model);


        //}

        //[TestMethod]
        //public async Task Create_WithNonExistingTerm_ReturnsRedirectToActionResult()
        //{
        //    GlossaryModel glossaryModel = new GlossaryModel { Term = "dsadsadasdaaa 123", Definition = "sad32", Id = 5 };

        //    _unitOfWorkMock.Setup(uow => uow.Glossary.Any(x => x.Term == glossaryModel.Term))
        //        .Returns(false);


        //    var tempDataMock = new MockTempDataDictionary();
        //    _controller.TempData = tempDataMock;


        //    var result = await _controller.Create(glossaryModel);

        //    Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        //    var redirectResult = (RedirectToActionResult)result;
        //    Assert.AreEqual(nameof(GlossaryController.Index), redirectResult.ActionName);

        //}

        //[TestMethod]
        //public async Task Edit_WithExistingId_ReturnsView()
        //{
        //    int id = 1;
        //    var obj = new GlossaryModel { Id = id };

        //    _unitOfWorkMock.Setup(uow => uow.Glossary.GetFirstOrDefault(It.IsAny<Expression<Func<GlossaryModel, bool>>>(), null))
        //        .Returns(obj);

        //    var result = await _controller.Edit(id);

        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual(obj, viewResult.Model);
        //}

        //[TestMethod]
        //public async Task Edit_WithValidModel_ReturnsRedirectToActionResult()
        //{
        //    int id = 1;
        //    var obj = new GlossaryModel { Id = id, Term = "Term" };

        //    _unitOfWorkMock.Setup(uow => uow.Glossary.Any(x => x.Term == obj.Term && x.Id != obj.Id))
        //        .Returns(false);

        //    _unitOfWorkMock.Setup(uow => uow.Glossary.Update(obj));

        //    var tempDataMock = new MockTempDataDictionary();
        //    _controller.TempData = tempDataMock;

        //    var result = await _controller.Edit(id, obj);

        //    Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        //    var redirectResult = (RedirectToActionResult)result;
        //    Assert.AreEqual(nameof(GlossaryController.Index), redirectResult.ActionName);
        //}




        //[TestMethod]
        //public async Task Delete_WithValidId_ReturnsView()
        //{
        //    int id = 1;
        //    var glossaryModel = new GlossaryModel { Id = id, Term = "Term 1" };
        //    _unitOfWorkMock.Setup(uow => uow.Glossary.GetFirstOrDefault(It.IsAny<Expression<Func<GlossaryModel, bool>>>(), null)).Returns(glossaryModel);

        //    var result = await _controller.Delete(id);

        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //    var viewResult = (ViewResult)result;
        //    Assert.AreEqual(glossaryModel, viewResult.Model);
        //}

        //[TestMethod]
        //public async Task Delete_WithInvalidId_ReturnsNotFound()
        //{
        //    int? id = null;

        //    var result = await _controller.Delete(id);

        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));


        //}

        //[TestMethod]
        //public async Task DeleteConfirmed_WithValidId_DeletesGlossaryTermAndRedirectsToIndex()
        //{

        //    int id = 1;
        //    var glossaryModel = new GlossaryModel { Id = id, Term = "Term 1" };
        //    _unitOfWorkMock.Setup(uow => uow.Glossary.GetFirstOrDefault(It.IsAny<Expression<Func<GlossaryModel, bool>>>(), null)).Returns(glossaryModel);

        //    var tempDataMock = new MockTempDataDictionary();
        //    _controller.TempData = tempDataMock;


        //    var result = await _controller.DeleteConfirmed(id);



        //    Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        //    var redirectResult = (RedirectToActionResult)result;
        //    Assert.AreEqual(nameof(GlossaryController.Index), redirectResult.ActionName);
        //}


    }



}