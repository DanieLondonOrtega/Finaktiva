using Finaktiva.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finaktiva.Infrastructur.DataAccess.Configurations
{
    public class EventLogsConfig : IEntityTypeConfiguration<EventLogs>
    {
        public void Configure(EntityTypeBuilder<EventLogs> builder)
        {
            builder.ToTable("EventLogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.Date)
                .HasColumnName("Date")
                .IsRequired(true);

            builder.HasOne(x => x.TypeEventLogs)
                .WithMany(x => x.EventsLogs)
                .HasForeignKey(x => x.IdType);
        }
    }
}
