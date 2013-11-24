using Machine.Specifications;
using Moq;
using RealEstate.Web.Controllers;

namespace MiniDropbox.Web.Specs
{
    public class given_a_account_controller_context
    {
        private static Mock<IReadOnlyRepository> _mockReadOnlyRepository;
        private static Mock<IWriteOnlyRepository> _mockWriteOnlyRepository;
        private static AccountController _accountController;

        private Establish context = () =>
            {
                _mockReadOnlyRepository = new Mock<IReadOnlyRepository>();
                _mockWriteOnlyRepository = new Mock<IWriteOnlyRepository>();
                _accountController = new AccountController(_mockReadOnlyRepository.Object,
                                                           _mockWriteOnlyRepository.Object);
            };
    }
}