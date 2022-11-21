using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.SModels
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int ConcurrencyId { get; set; }
    }
}
