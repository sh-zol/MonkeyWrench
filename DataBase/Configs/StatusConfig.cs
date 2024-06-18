using Domain.Core.HomeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configs
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Massage)
                .IsRequired()
                .HasMaxLength(200);

            // seed
            builder.HasData(new List<Status>
            {
                new Status { Id = 1, Massage = "درخواست ایجاد شد و در انتظار پیشنهاد متخصصان" },
                new Status{Id = 2, Massage = "پیشنهاد متخصص قبول شد"},
                new Status{Id = 3, Massage = "متخصص به محل رسید و شروع به انجام کار است" },
                new Status{Id = 4, Massage = "کار متخصص به پایان رسید و در انتظار پرداخت"},
                new Status{Id = 5, Massage = "پرداخت انجام شد و درخواست به پایان رسید"} });
        }
    }
}
