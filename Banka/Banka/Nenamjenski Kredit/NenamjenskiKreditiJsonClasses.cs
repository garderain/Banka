namespace Banka
{
    public class NenamjenskiKreditiJson
    {
        public List<NenamjenskiKreditJson> nenamjenskiKrediti { get; set; }

        public NenamjenskiKreditiJson()
        {
            nenamjenskiKrediti = new();
        }
    }




    public class NenamjenskiKreditJson
    {
        public string IdKredit { get; set; }
        public float Glavnica { get; set; }
        public float KamatnaStopa { get; set; }
        public float RokOtplate { get; set; }

    }

}
