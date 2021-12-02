using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Domain.Repositories
{
    public interface IEntityRepositoryFactory
    {
        IEntityRepository CreateRepository();
    }
}
