using System;
using System.ComponentModel.DataAnnotations;

namespace TransplantationCare.Core.Models.DataBase
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }
        
        public int ReviewerId { get; set; }
       
        public DateTime DateTimeReview { get; set; }
        
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}
