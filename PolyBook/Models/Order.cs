﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolyBook.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;//múi giờ địa phương
        //public DateTime CreatedDate { get; set; } = DateTime.UtcNow; múi giờ quốc tế
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress] //điều kiện format của email như @gmail.com
        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string? MobileNumber { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}