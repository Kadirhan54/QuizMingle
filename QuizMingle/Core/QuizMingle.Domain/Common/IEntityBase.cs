

namespace QuizMingle.Domain.Common
{
    public interface IEntityBase<Tkey> 
    {
        public Tkey Id { get; set; }


    }
}
