using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using NevskyFond.Encyclopedia.Data.Store.Church;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using NevskyFond.Encyclopedia.Domain;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch;
using NevskyFond.SocialNetwork.Communication.Client;
using NevskyFond.SocialNetwork.Communication.Models.Queries.Comments;
using NevskyFond.SocialNetwork.Communication.Models.Results.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Tests.Queries.Churchs
{
    public class GetExtendedChurchHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly IMapper _mapper;

        public GetExtendedChurchHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetExtendedChurchHandlerQuery, GetChurchByIdStoreQuery>();

                cfg.CreateMap<GetChurchByIdStoreDTO, GetExtendedChurchDTO>();
                cfg.CreateMap<GetChurchByIdStoreResult, GetExtendedChurchHandlerResult>();

                cfg.CreateMap<CommentResultDTO, CommentResultHandlerDTO>();
            }).CreateMapper();
        }

        [Fact]
        public async Task Handle_ReturnsIsFoundChurchWithCommentsFilter()
        {
            var mapperMock = new Mock<IMapper>();
            var churchStoreMock = new Mock<IChurchStore>();
            var socialNetworkClientMock = new Mock<ISocialNetworkClient>();
            var loggerMock = new Mock<ILogger<GetExtendedChurchHandler>>();

            var queryHandler = _fixture.Build<GetExtendedChurchHandlerQuery>()
                .Create();

            var queryStore = _mapper.Map<GetChurchByIdStoreQuery>(queryHandler);

            mapperMock.Setup(m => m.Map(It.IsAny<GetExtendedChurchHandlerQuery>(), It.IsAny<GetChurchByIdStoreQuery>()))
                .Returns((GetExtendedChurchHandlerQuery query, GetChurchByIdStoreQuery _) =>
                {
                    return queryStore;
                });

            var getChurchByIdStoreResult = _fixture.Create<GetChurchByIdStoreResult>();
            getChurchByIdStoreResult.Church = _fixture.Build<GetChurchByIdStoreDTO>()
                                                       .With(c => c.Id, queryStore.Id)
                                                       .Create();

            churchStoreMock.Setup(c => c.GetChurchByIdAsync(It.IsAny<GetChurchByIdStoreQuery>()))
                           .ReturnsAsync(getChurchByIdStoreResult);

            var resultHandlerChecked = _mapper.Map<GetExtendedChurchHandlerResult>(getChurchByIdStoreResult);
            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdStoreResult>(), It.IsAny<GetExtendedChurchHandlerResult>()))
                .Returns((GetChurchByIdStoreResult query, GetExtendedChurchHandlerResult _) =>
                {
                    return resultHandlerChecked;
                });

            // Теперь нужно замочить GetCommentsAsync
            var commentsResultMock = new GetCommentsResult
            {
                Comments = _fixture.CreateMany<CommentResultDTO>().ToList()
            };

            mapperMock.Setup(m => m.Map<IEnumerable<CommentResultHandlerDTO>>(It.IsAny<IEnumerable<CommentResultDTO>>()))
                .Returns<IEnumerable<CommentResultDTO>>(comments => comments.Select(c => _mapper.Map<CommentResultHandlerDTO>(c)));

            socialNetworkClientMock.Setup(x => x.Comments.GetCommentsAsync(It.IsAny<GetCommentsQuery>()))
                                   .ReturnsAsync(commentsResultMock);

            var handler = new GetExtendedChurchHandler(
                mapperMock.Object, churchStoreMock.Object, socialNetworkClientMock.Object, loggerMock.Object);


            // Act
            var result = await handler.Handle(queryHandler, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Church);
            Assert.Equal(resultHandlerChecked.Church, result.Church);

            Assert.Equal(resultHandlerChecked.Comments.Count(), result.Comments.Count());
        }

        [Fact]
        public async Task Handle_ReturnsIsFoundChurchWithoutCommentsFilter()
        {
            var mapperMock = new Mock<IMapper>();
            var churchStoreMock = new Mock<IChurchStore>();
            var socialNetworkClientMock = new Mock<ISocialNetworkClient>();
            var loggerMock = new Mock<ILogger<GetExtendedChurchHandler>>();

            var queryHandler = _fixture.Build<GetExtendedChurchHandlerQuery>()
                .Without(e => e.CommentsFilter)
                .Create();

            var queryStore = _mapper.Map<GetChurchByIdStoreQuery>(queryHandler);

            mapperMock.Setup(m => m.Map(It.IsAny<GetExtendedChurchHandlerQuery>(), It.IsAny<GetChurchByIdStoreQuery>()))
                .Returns((GetExtendedChurchHandlerQuery query, GetChurchByIdStoreQuery _) =>
                {
                    return queryStore;
                });

            var getChurchByIdStoreResult = _fixture.Create<GetChurchByIdStoreResult>();
            getChurchByIdStoreResult.Church = _fixture.Build<GetChurchByIdStoreDTO>()
                                                       .With(c => c.Id, queryStore.Id)
                                                       .Create();

            churchStoreMock.Setup(c => c.GetChurchByIdAsync(It.IsAny<GetChurchByIdStoreQuery>()))
                           .ReturnsAsync(getChurchByIdStoreResult);

            var resultHandlerChecked = _mapper.Map<GetExtendedChurchHandlerResult>(getChurchByIdStoreResult);
            mapperMock.Setup(m => m.Map(It.IsAny<GetChurchByIdStoreResult>(), It.IsAny<GetExtendedChurchHandlerResult>()))
                .Returns((GetChurchByIdStoreResult query, GetExtendedChurchHandlerResult _) =>
                {
                    return resultHandlerChecked;
                });

            var handler = new GetExtendedChurchHandler(
                mapperMock.Object, churchStoreMock.Object, socialNetworkClientMock.Object, loggerMock.Object);


            // Act
            var result = await handler.Handle(queryHandler, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Church);
            Assert.Equal(resultHandlerChecked.Church, result.Church);
        }

        [Fact]
        public async Task Handle_ReturnsNotFoundChurch()
        {
            var mapperMock = new Mock<IMapper>();
            var churchStoreMock = new Mock<IChurchStore>();
            var socialNetworkClientMock = new Mock<ISocialNetworkClient>();
            var loggerMock = new Mock<ILogger<GetExtendedChurchHandler>>();

            var queryHandler = _fixture.Create<GetExtendedChurchHandlerQuery>();
            var queryStore = _mapper.Map< GetChurchByIdStoreQuery>(queryHandler);

            mapperMock.Setup(m => m.Map(It.IsAny<GetExtendedChurchHandlerQuery>(), It.IsAny<GetChurchByIdStoreQuery>()))
                .Returns((GetExtendedChurchHandlerQuery query, GetChurchByIdStoreQuery _) =>
                {
                    return queryStore;
                }); 

            var getChurchByIdStoreResult = new GetChurchByIdStoreResult();

            churchStoreMock.Setup(c => c.GetChurchByIdAsync(It.IsAny<GetChurchByIdStoreQuery>()))
                           .ReturnsAsync(getChurchByIdStoreResult);

            var handler = new GetExtendedChurchHandler(
                mapperMock.Object, churchStoreMock.Object, socialNetworkClientMock.Object, loggerMock.Object);


            // Act
            var result = await handler.Handle(queryHandler, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}