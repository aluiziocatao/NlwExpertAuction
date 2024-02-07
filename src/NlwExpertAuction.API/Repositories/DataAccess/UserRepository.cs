using NlwExpertAuction.API.Contracts;
using NlwExpertAuction.API.Entities;
using System.Linq;

namespace NlwExpertAuction.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly NlwExpertAuctionDbContext _dbContext;

    public UserRepository(NlwExpertAuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool ExistUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
