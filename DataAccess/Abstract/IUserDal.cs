using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;

public interface IUserDal : IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}