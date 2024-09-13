using AutoFixture.Xunit2;
using AutoMapper;
using Moq;
using Newtonsoft.Json;
using Application.Features.Users.Commands.CreateUser;
using Application.Contracts.Persistence;
using Domain.Entities;
using FluentValidation.Results;
using Xunit;
using Tests.UnitTests.Helpers;

namespace Tests.UnitTests.Services.Users
{
    public class UserHandlerTest
    {
        private CreateUserCommand GetValidCreateUserCommand()
        {
            return new CreateUserCommand
            {
                Name = "Ervin Howell",
                UserName = "Antonette",
                Email = "Shanna@melissa.tv",
                Address = new()
                {
                    Street = "Victor Plains",
                    Suite = "Suite 879",
                    City = "Wisokyburgh",
                    Zipcode = "90566-7771",
                    Geo = new()
                    {
                        Lat = "-43.9509",
                        Lng = "-34.4618"
                    }
                },
                Phone = "010-692-6593 x09125",
                Website = "anastasia.net",
                Company = new()
                {
                    Name = "Deckow Crist",
                    CatchPhrase = "Proactive didactic contingency",
                    Bs = "synergize scalable supply-chains"
                }
            };
        }

        private User GetTestUser()
        {
            return new User
            {
                Id = 1,
                Name = "Ervin Howell",
                UserName = "Antonette",
                Email = "Shanna@melissa.tv",
                Address = new()
                {
                    Street = "Victor Plains",
                    Suite = "Suite 879",
                    City = "Wisokyburgh",
                    Zipcode = "90566-7771",
                    Geo = new()
                    {
                        Lat = "-43.9509",
                        Lng = "-34.4618"
                    }
                },
                Phone = "010-692-6593 x09125",
                Website = "anastasia.net",
                Company = new()
                {
                    Name = "Deckow Crist",
                    CatchPhrase = "Proactive didactic contingency",
                    Bs = "synergize scalable supply-chains"
                }
            };
        }

        private CreateUserDto GetTestUserDto()
        {
            return new CreateUserDto
            {
                Id = 1,
                Name = "Ervin Howell",
                UserName = "Antonette",
                Email = "Shanna@melissa.tv",
                Address = new()
                {
                    Street = "Victor Plains",
                    Suite = "Suite 879",
                    City = "Wisokyburgh",
                    Zipcode = "90566-7771",
                    Geo = new()
                    {
                        Lat = "-43.9509",
                        Lng = "-34.4618"
                    }
                },
                Phone = "010-692-6593 x09125",
                Website = "anastasia.net",
                Company = new()
                {
                    Name = "Deckow Crist",
                    CatchPhrase = "Proactive didactic contingency",
                    Bs = "synergize scalable supply-chains"
                }
            };
        }

        [Theory, GenerateDefaultTestData]
        public async Task CreateUserCommandHandler_Handle_Returns_CreateUserCommandResponse(
            [Frozen] Mock<IRepository<User>> userRepositoryMock,
            [Frozen] Mock<IMapper> mapperMock,
            CreateUserCommandHandler createUserCommandHandler)
        {
            // Arrange
            var expectedResponse = new CreateUserCommandResponse
            {
                User = GetTestUserDto()
            };

            var testRequest = GetValidCreateUserCommand();
            var testUser = GetTestUser();

            mapperMock
                .Setup(x => x.Map<User>(It.IsAny<CreateUserCommand>()))
                .Returns(testUser);

            userRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(testUser));

            mapperMock
               .Setup(x => x.Map<CreateUserDto>(It.IsAny<User>()))
               .Returns(GetTestUserDto());

            // Act
            var testResponse = await createUserCommandHandler.Handle(testRequest, new CancellationToken());

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectedResponse), JsonConvert.SerializeObject(testResponse));
        }

        [Theory, GenerateDefaultTestData]
        public void CreateUserCommand_With_Invalid_Name_Input_Returns_Validation_Exception(CreateUserCommandValidator validator)
        {
            // Test Invalid Name Format
            var invalidNameRequest = GetValidCreateUserCommand();
            invalidNameRequest.Name = "123"; // Invalid name

            // Act
            var response = validator.Validate(invalidNameRequest);

            // Assert
            Assert.False(response.IsValid);

            // Valid name scenario
            var validNameRequest = GetValidCreateUserCommand();

            // Act
            response = validator.Validate(validNameRequest);

            // Assert
            Assert.True(response.IsValid);
        }

        // New test cases for other fields
        [Theory, GenerateDefaultTestData]
        public void CreateUserCommand_With_Invalid_Email_Input_Returns_Validation_Exception(CreateUserCommandValidator validator)
        {
            var invalidEmailRequest = GetValidCreateUserCommand();
            invalidEmailRequest.Email = "invalid-email"; // Invalid email

            var response = validator.Validate(invalidEmailRequest);

            Assert.False(response.IsValid);

            var validEmailRequest = GetValidCreateUserCommand();
            validEmailRequest.Email = "Shanna@melissa.tv"; // Valid email

            response = validator.Validate(validEmailRequest);

            Assert.True(response.IsValid);
        }

        [Theory, GenerateDefaultTestData]
        public void CreateUserCommand_With_Invalid_Phone_Input_Returns_Validation_Exception(CreateUserCommandValidator validator)
        {
            var invalidPhoneRequest = GetValidCreateUserCommand();
            invalidPhoneRequest.Phone = "invalid-phone-more-than-ten-char"; // Invalid phone number

            var response = validator.Validate(invalidPhoneRequest);

            Assert.False(response.IsValid);

            var validPhoneRequest = GetValidCreateUserCommand();
            validPhoneRequest.Phone = "01009125"; // Valid phone number

            response = validator.Validate(validPhoneRequest);

            Assert.True(response.IsValid);
        }

        [Theory, GenerateDefaultTestData]
        public void CreateUserCommand_With_Invalid_Website_Input_Returns_Validation_Exception(CreateUserCommandValidator validator)
        {
            var invalidWebsiteRequest = GetValidCreateUserCommand();
            invalidWebsiteRequest.Website = "invalidwebsitemorethantwentycharacters"; // Invalid website

            var response = validator.Validate(invalidWebsiteRequest);

            Assert.False(response.IsValid);

            var validWebsiteRequest = GetValidCreateUserCommand();
            validWebsiteRequest.Website = "anastasia.net"; // Valid website

            response = validator.Validate(validWebsiteRequest);

            Assert.True(response.IsValid);
        }
    }
}