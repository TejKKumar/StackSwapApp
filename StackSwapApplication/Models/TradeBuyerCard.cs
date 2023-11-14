﻿using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Models
{
    public class TradeBuyerCard : BaseEntity
    {
        private uint _id;
        public override uint Id { get => _id; set => _id = value; }

        public uint TradeId;
        public Trade Trade { get; set; }
        public uint BuyerId { get; set; }
        public uint CardId { get; set; }
    }
}