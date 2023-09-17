﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class EmployerVM : UserVM
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên nhà tuyển dụng")]
        public string EmployerName { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Địa chỉ")]
		public string Address { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Mô tả")]
		public string Description { get; set; }

    }
}
