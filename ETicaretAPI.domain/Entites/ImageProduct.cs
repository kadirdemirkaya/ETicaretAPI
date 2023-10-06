using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class ImageProduct : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}
