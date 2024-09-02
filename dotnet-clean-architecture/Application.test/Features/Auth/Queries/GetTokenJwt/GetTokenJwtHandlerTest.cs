using Application.Features.Auth.Queries.GetTokenJwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.test.Features.Auth.Queries.GetTokenJwt
{
    public class GetTokenJwtHandlerTest
    {
        [Fact]
        public async Task Handle_InvalidEmail_ShouldReturnsNull()
        {
            // Arrange
            GetTokenJwtQuery request = new()
            {
                Email = "someone@somewhere.com"
            };
            CancellationToken cancellationToken = CancellationToken.None;
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, default, default, default, default, default, default, default, default);
            mockUserManager.Setup(it => it.FindByEmailAsync(request.Email))
                .Returns(Task.FromResult<IdentityUser>(null));
            var mockConfiguration = new Mock<IConfiguration>();

            var handler = new GetTokenJwtHandler(mockUserManager.Object, mockConfiguration.Object);
            // Act
            var result = await handler.Handle(request, cancellationToken);
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_CorrectEmailInvalidPassword_ShouldReturnsNull()
        {
            // Arrange
            GetTokenJwtQuery request = new()
            {
                Email = "someone@somewhere.com",
                Password = "password"
            };
            var user = new IdentityUser
            {
                Email = request.Email
            };
            CancellationToken cancellationToken = CancellationToken.None;
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, default, default, default, default, default, default, default, default);
            mockUserManager.Setup(it => it.FindByEmailAsync(request.Email))
                .Returns(Task.FromResult(user));
            mockUserManager.Setup(it => it.CheckPasswordAsync(user, It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            var mockConfiguration = new Mock<IConfiguration>();

            var handler = new GetTokenJwtHandler(mockUserManager.Object, mockConfiguration.Object);
            // Act
            var result = await handler.Handle(request, cancellationToken);
            // Assert
            Assert.Null(result);

        }
    }
}
