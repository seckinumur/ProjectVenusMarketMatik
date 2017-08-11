using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikEntity.Model
{
   public class Kullanicilar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Benzersiz { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Yetki { get; set; }
    }
}
