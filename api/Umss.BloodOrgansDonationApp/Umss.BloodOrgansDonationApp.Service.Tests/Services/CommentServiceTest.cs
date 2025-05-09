using Moq;
using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class CommentServiceTest : IClassFixture<RepositoryFixture>
    {
        private readonly RepositoryFixture repositoryFixture;
        private readonly CommentService commentService;
        public CommentServiceTest(RepositoryFixture repositoryFixture)
        {
            this.repositoryFixture = repositoryFixture;
            this.commentService = new CommentService(repositoryFixture.CommentRepository);
        }
        private IEnumerable<Comment> GetComments()
        {
            Comment[] comments = new Comment[8] {
                new Comment { Id = Guid.NewGuid(), Description = "First Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },   
                new Comment { Id = Guid.NewGuid(), Description = "Second Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Third Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Fourth Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Fifth Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Sixth Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Seventh Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
                new Comment { Id = Guid.NewGuid(), Description = "Eight Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now },
            };

            return comments;
        }

        private Comment GetComment()
        {
            Comment comment = new Comment { Id = Guid.NewGuid(), Description = "First Comment", DonationPostId = Guid.NewGuid(), CreatedAt = DateTime.Now };

            return comment;
        }

        private CommentRequest GetCommentRequest()
        {
            var commentRequest = new CommentRequest
            {
                Description = "New Comment",
                DonationPostId = Guid.NewGuid(),
            };

            return commentRequest;
        }

        [Fact]
        public async void GetAll()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetComments());
            var comments = await this.commentService.GetAll();

            Assert.NotEmpty(comments);
        }

        [Fact]
        public async void GetById()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetComment());
            var comment = await this.commentService.Get(Guid.NewGuid());

            Assert.NotNull(comment);
        }

        [Fact]
        public async void Create()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Create(It.IsAny<Comment>())).ReturnsAsync(this.GetComment);
            CommentResponse commentResponse = await this.commentService.Create(this.GetCommentRequest());

            Assert.NotNull(commentResponse);
        }

        [Fact]
        public async void Delete()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.commentService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetComment);
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Update(It.IsAny<Comment>())).ReturnsAsync(this.GetComment);
            CommentResponse commentResponse = await this.commentService.Update(Guid.NewGuid(), this.GetCommentRequest());

            Assert.NotNull(commentResponse);
        }
    }
}
