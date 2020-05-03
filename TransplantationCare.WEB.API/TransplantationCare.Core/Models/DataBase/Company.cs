﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public List<User> Users { get; set; }
    }
}
