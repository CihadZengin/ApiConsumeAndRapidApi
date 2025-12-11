using System.ComponentModel.DataAnnotations;

namespace HotelProject.WepUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet İkon Linki Giriniz")]
        public string SeviceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı  Giriniz")]
        [StringLength(100,ErrorMessage ="Hizmet Başlığı En Fazla 100 Karakter Olabilir.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
