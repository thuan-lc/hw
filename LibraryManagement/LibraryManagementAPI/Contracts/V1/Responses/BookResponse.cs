using LibraryManagementAPI.Domains;
using Microsoft.AspNetCore.Identity;
using System;

namespace LibraryManagementAPI.Contracts.V1.Responses
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Credits { get; set; }
        public int Quantities { get; set; }
        public int AvailableQuantities { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
