using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.OrderAggregate;

namespace Infrastructure.Data.Config
{
    internal class OrderConfig
    {
        public class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.OwnsOne(o => o.ShippToAddress, a =>
                {
                    a.WithOwner();
                });
                builder.Navigation(a => a.ShippToAddress).IsRequired();
                builder.Property(s => s.OrderStatus)
                    .HasConversion(
                        o => o.ToString(),
                        o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                    );
                builder.HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
                
            }
        }
    }
}
