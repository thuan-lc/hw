using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Domains
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Credits { get; set; }
        public int Quantities { get; set; }
        [ConcurrencyCheck]
        public int AvailableQuantities { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public CustomUser CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
