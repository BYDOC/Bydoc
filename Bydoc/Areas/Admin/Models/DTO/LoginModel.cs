using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bydoc.Areas.Admin.Models.DTO
{
    public class LoginModel
    {

        //login bilgilerini alıp entitydeki adminuser ile karsılastıracak(DATA TRANSFER OBJECT)

        [Required(ErrorMessage ="Mail adresi girin")]
        [EmailAddress(ErrorMessage ="Düzgün email adresi girin")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Sifre girin")]
        public string  Password { get; set; }
    }
}