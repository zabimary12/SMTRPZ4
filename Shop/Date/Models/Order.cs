using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [StringLength(20)]
        [Required(ErrorMessage ="Длинна имение должна быть больше 5 символов")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длинна фамилии должна быть больше 5 символов")]
        public string surename { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длинна адреса должна быть больше 5 символов")]
        public string adress { get; set; }
        [Display(Name = "Введите номер телефона")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длинна номера телефона должна быть больше 9 символов")]
        public string phone { get; set; }
        [Display(Name = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public List<OrderDetail> orderDetails { get; set; }
    }     
}
