﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string MemberEmail { get; set; }
        public DateTime DatePlaced { get; set; }

    }
}
