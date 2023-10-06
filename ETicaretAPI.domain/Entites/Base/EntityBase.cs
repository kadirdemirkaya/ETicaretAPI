namespace ETicaretAPI.domain.Entites.Base
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
