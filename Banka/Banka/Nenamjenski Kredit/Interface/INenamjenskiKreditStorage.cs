namespace Banka
{
    public interface INenamjenskiKreditStorage
    {
        void InicijalizirajStorage();
        public void SpremiStorage();
        public INenamjenskiKredit? GetNenamjenskiKredit(Guid IdKredita);
        public void AddNenamjenskiKredit(INenamjenskiKredit nenamjenskiKredit);
    }
}
