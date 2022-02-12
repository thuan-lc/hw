using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Domains
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TransId { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public CustomUser Reader { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
        public double Credits { get; set; }
        public int Quantities { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
