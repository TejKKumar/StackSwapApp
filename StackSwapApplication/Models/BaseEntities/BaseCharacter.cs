﻿using System.ComponentModel.DataAnnotations.Schema;

//By Tejas 
namespace StackSwapApplication.Models.BaseEntities
{
    public class BaseCharacter : BaseEntity
    {
        private uint _id;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override uint Id { get => _id; set => SetProperty(ref _id, value); }


        public uint GetID => _id;
    }
}
