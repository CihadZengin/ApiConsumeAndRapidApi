using System.ComponentModel.DataAnnotations;

namespace HotelProject.WepUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet İkon Linki Giriniz")]
        public string SeviceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı  Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En Fazla 100 Karakter Olabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet Açıklaması  Giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması En Fazla 500 Karakter Olabilir.")]
        public string Description { get; set; }
    }
}
