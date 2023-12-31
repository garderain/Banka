﻿namespace Banka
{
    public class DuplicateOibException : Exception
    {
        public DuplicateOibException(string message) : base(message)
        {

        }
    }
    public class MalformedOibException : Exception
    {
        public MalformedOibException(string message) : base(message)
        {

        }
    }
    //Ako osoba nije izabrala nijedan racun
    public class InvalidAccountOption : Exception
    {
        public InvalidAccountOption(string message) : base(message)
        {

        }
    }
    // Ako osoba ima postojeci ziro racun
    public class HasZiroAccount : Exception
    {
        public HasZiroAccount(string message) : base(message) { }
    }
    // Ako nema dovoljno primanja za trazeni kredit
    public class InsufficientIncome : Exception
    {
        public InsufficientIncome(string message) : base(message) { }
    }

    public class MissingNenamjenskiKreditException : Exception
    {
        public MissingNenamjenskiKreditException(string message) : base(message) { }
    }


}

