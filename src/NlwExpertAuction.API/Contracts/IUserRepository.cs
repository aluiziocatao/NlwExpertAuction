using NlwExpertAuction.API.Entities;

namespace NlwExpertAuction.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
