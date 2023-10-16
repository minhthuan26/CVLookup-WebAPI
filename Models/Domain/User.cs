﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
	public class User
	{
		[Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Yêu cầu nhập đúng email")]
		public string Email { get; set; }

		[Display(Name = "Số điện thoại")]
		[DataType(DataType.PhoneNumber, ErrorMessage = "Yêu cầu nhập đúng số điện thoại")]
		public string? PhoneNumber { get; set; }

		[Display(Name = "Ảnh đại diện")]
		public string? Avatar { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

    }
}
