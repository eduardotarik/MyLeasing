﻿using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Models
{
    public class OwnerViewModel : Owner
    {
        [Display(Name = "Photo")]
        public IFormFile PhotoFile { get; set; }
    }
}
