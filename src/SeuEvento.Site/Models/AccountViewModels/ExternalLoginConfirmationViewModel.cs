﻿using System.ComponentModel.DataAnnotations;

namespace SeuEvento.Site.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
