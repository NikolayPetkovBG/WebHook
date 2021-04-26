using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebHook.Common.ApiClients;
using WebHook.Frontend.Services;
using Xunit;

namespace WebHook.Frontend.Tests
{
    public class WebHookServiceTests
    {
        [Fact]
        public async Task CallAllWebHooksAsync_ShouldGoThruAllWebHooks()
        {
            // Arrange
            Mock<IWebHookApiClient> apiClientMock = new Mock<IWebHookApiClient>();
            apiClientMock.Setup(x => x.GetAllWebHooksAsync())
                .ReturnsAsync(new List<Common.Models.WebHook>()
                {
                    new Common.Models.WebHook
                    {
                        Id = 123,
                        Name = "WebHook_Name",
                        Url = "WebHook_Url"
                    }
                });

            IWebHookService service = new WebHookService(apiClientMock.Object);

            // Act
            await service.CallAllWebHooksAsync();
            apiClientMock.Verify(x => x.CallWebHookAsync(It.Is<int>(x => x == 123)), Times.Once);
        }
    }
}
