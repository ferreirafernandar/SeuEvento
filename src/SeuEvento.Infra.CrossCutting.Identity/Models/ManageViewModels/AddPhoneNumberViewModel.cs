﻿using System.ComponentModel.DataAnnotations;

namespace SeuEvento.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
