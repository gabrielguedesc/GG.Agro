using AutoFixture.Xunit2;
using GG.Agro.Application.Commands.Contract;
using GG.Agro.Infra.Abstractions;
using GG.Agro.Tests.Cases.Application.Contract.RuleModels;
using GG.Agro.Tests.Core;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GG.Agro.Tests.Cases.Application.Contract.Handlers
{
    [Trait("Contract", "Create")]
    public class CreateContractHandlerTests
    {
        [Theory(DisplayName = "When invalid contract name, testing false output"), AutoAssert]
        public async Task CreateContractHandler_InvalidName_ShouldReturnFalse(ContractWithInvalidName invalidContract, 
            CreateContractHandler handler)
        {
            // Act
            var result = await handler.Handle(invalidContract, CancellationToken.None);

            // Asserts
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Theory(DisplayName = "When valid contract, testing true output"), AutoAssert]
        public async Task CreateContractHandler_ValidContract_ShouldReturnTrue([Frozen] Mock<IUnitOfWork> uow, 
            ValidContract contract, CreateContractHandler handler)
        {
            // Act
            var result = await handler.Handle(contract, CancellationToken.None);

            // Asserts
            Assert.True(result.IsValid);

            uow.Verify(c => c.Contracts.Add(It.IsAny<Domain.Entities.Contract>()), Times.Once);
            uow.Verify(u => u.Commit(), Times.Once);
        }
    }
}
