﻿using Shop.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public List<Product> Products { get; set; }

        public Guid? UserId { get; set; }

        public ApplicationUser User { get; set; }

        public double TotalSum { get; set; }

        public DateTime PurchaseTime { get; set; }

        public PaymentType PaymentType { get; set; }

        public DeliveryType DeliveryType { get; set; }
    }
}