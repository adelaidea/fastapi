using FastAPI.Domain.Core;

namespace FastAPI.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
