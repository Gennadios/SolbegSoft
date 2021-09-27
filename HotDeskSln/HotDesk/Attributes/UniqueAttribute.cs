using HotDesk.Models.Repositories;
using System.ComponentModel.DataAnnotations;


namespace HotDesk.Attributes
{
    public class UniqueAttribute : ValidationAttribute
    {
        // TODO: complete logic
        private IRepository _repository;

        public UniqueAttribute(IRepository repository) => _repository = repository;

    }
}
