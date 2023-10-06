using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.domain.Entites
{
    public class Image : EntityBase
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }


        public AppUser AppUser { get; set; }
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
    }
}
