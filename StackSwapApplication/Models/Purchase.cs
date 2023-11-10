﻿using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.Models
{
    public class Purchase
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        public TradeUser? Buyer { get; set; }

        [Required]
        public List<Card>? Cards { get; set; }

        [Required]
        public DateTime? PurchaseDate { get; set; }
    }
}
