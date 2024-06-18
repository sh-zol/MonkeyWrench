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
    public class ExpertSkillConfig : IEntityTypeConfiguration<ExpertSkill>
    {
        public void Configure(EntityTypeBuilder<ExpertSkill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Skills);
            builder.HasOne(x => x.Service)
                .WithMany(x => x.Skills);
        }
    }
}
