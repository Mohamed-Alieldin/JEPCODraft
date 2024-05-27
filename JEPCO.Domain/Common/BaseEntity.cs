using System.ComponentModel.DataAnnotations;

namespace JEPCO.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
