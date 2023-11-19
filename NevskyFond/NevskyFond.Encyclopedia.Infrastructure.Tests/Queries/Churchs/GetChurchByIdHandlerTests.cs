using AutoMapper;
using Moq;
using NevskyFond.Encyclopedia.Data.Store.Church;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using NevskyFond.Encyclopedia.Domain;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Tests.Queries.Churchs
{
    public class GetChurchByIdHandlerTests
    {
        [Theory]
        [InlineData(1, "Храм Василия Блаженного")]
        public async Task ReturnsCorrectResult(int churchId, string churchName)
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var churchStoreMock = new Mock<IChurchStore>();

            var query = new GetChurchByIdHandlerQuery
            {
                Id = churchId
            };

            var expectedResult = new GetChurchByIdHandlerResult()
            {
                Church = new ChurchHandlerDTO()
                {
                    Id = churchId,
                    Name = churchName
                }
            };

            // Настройка моков для работы с запросом
            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdHandlerQuery>(), It.IsAny<GetChurchByIdStoreQuery>()))
                      .Returns(new GetChurchByIdStoreQuery());

            churchStoreMock.Setup(c => c.GetChurchByIdAsync(It.IsAny<GetChurchByIdStoreQuery>()))
                           .ReturnsAsync(new GetChurchByIdStoreResult());

            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdStoreResult>(), It.IsAny<GetChurchByIdHandlerResult>()))
                      .Returns(expectedResult);

            var handler = new GetChurchByIdHandler(mapperMock.Object, churchStoreMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedResult.Church.Id, result.Church.Id);
            Assert.Equal(expectedResult.Church.Name, result.Church.Name);
        }

        [Theory]
        [InlineData(123)]
        public async Task ReturnsNullableChurchResult(int churchId)
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var churchStoreMock = new Mock<IChurchStore>();

            var query = new GetChurchByIdHandlerQuery
            {
                Id = churchId
            };

            var expectedResult = new GetChurchByIdHandlerResult();

            // Настройка моков для работы с запросом
            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdHandlerQuery>(), It.IsAny<GetChurchByIdStoreQuery>()))
                      .Returns(new GetChurchByIdStoreQuery());

            churchStoreMock.Setup(c => c.GetChurchByIdAsync(It.IsAny<GetChurchByIdStoreQuery>()))
                           .ReturnsAsync(new GetChurchByIdStoreResult());

            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdStoreResult>(), It.IsAny<GetChurchByIdHandlerResult>()))
                      .Returns(expectedResult);

            var handler = new GetChurchByIdHandler(mapperMock.Object, churchStoreMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result.Church);
        }
    }
}