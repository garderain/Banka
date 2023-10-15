using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banka
{
    public class TekuciRacunConfigurations : IEntityTypeConfiguration<TekuciRacun>
    {
        public void Configure(EntityTypeBuilder<TekuciRacun> builder)
        {
            builder.HasKey(tekuciRacun => tekuciRacun.IBAN);
            builder.Property(tekuciRacun => tekuciRacun.IBAN).HasMaxLength(21);
            builder.Property(tekuciRacun => tekuciRacun.StanjeRacuna);
            builder.Property(tekuciRacun => tekuciRacun.RezerviraniIznos);
            builder.Property(tekuciRacun => tekuciRacun.LimitIsplata);
            builder.Property(tekuciRacun => tekuciRacun.LimitUplata);
        }
    }
}
