using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FastAPI.Domain.Services
{
    public class UserDomainService : DomainService<User> , IUserDomainService
    {
        private readonly IRepository<User> repository;

        public UserDomainService(IRepository<User> repository) : base(repository)
        {
            this.repository = repository;
        }        

        protected override bool IsValid(User entity, out string[] errors)
        {
            var listErros = new List<string>();

            if (CheckEmailExists(entity.Email, entity.Id))
            {
                listErros.Add("The email already exists!");
            }

            errors = listErros.ToArray();

            return !listErros.Any();

        }

        public override Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            var dbEntity = repository.Get(entity.Id);

            dbEntity.Name = entity.Name;

            return base.UpdateAsync(dbEntity, cancellationToken);
        }

        private bool CheckEmailExists(string email, int currentId)
        {
            var filter = this.repository.CreateFilter();
            filter.AddCriteria(x => x.Email == email && x.Id != currentId);
            return this.repository.Any(filter);
        }
    }
}
