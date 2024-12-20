using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogretmen
    {   
        [Key]
        public int OgretmenId { get; set; }

        public string? OgretmenAd { get; set; }
        public string? OgretmenSoyad { get; set; }
        
         public string AdSoyad { 
            get{
                return this.OgretmenAd +" "+ this.OgretmenSoyad;
                } 
            }

        public string? Email { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =false)]

        public DateTime BaslamaTarihi { get; set; }

        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>(); // bir öğretmen birden fazla kursu verebilir bire çok ilişki


    }
}