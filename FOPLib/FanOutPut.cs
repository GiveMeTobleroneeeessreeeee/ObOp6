using System;

namespace FOPLib
{
    public class FanOutPut
    {

        private double _fugt;
        private double _temp;
        private string _navn;

        public FanOutPut(int id, double fugt, double temp, string navn)
        {
            Id = id;
            Navn = navn;
            Temp = temp;
            Fugt = fugt;
        }


        //public FanOutPut()
        //{

        //}

        public int Id { get; set; }
        public string Navn
        {
            get { return _navn; }
            set
            {
                if (value.Length >= 2)
                {
                    _navn = value;
                }
                else
                {
                    throw new Exception("Navn for kort");
                }
            }
        }
        /// <summary>
        /// Temp for temperatur,
        /// værdien er i celsius.
        /// </summary>
        public double Temp
        {
            get { return _temp; }
            set
            {
                if (value < 15)
                {
                    throw new Exception("Temperatur for lav");
                }

                if (value > 25)
                {
                    throw new Exception("Temperatur for høj");
                }

                if (value > 15 && value < 25)
                {
                    _temp = value;
                }
            }
        }
        /// <summary>
        /// Fugt for fugtighed angives i procent.
        /// </summary>
        public double Fugt
        {
            get { return _fugt; }
            set
            {
                if (value < 30)
                {
                    throw new Exception("Fugtværdi for lav");
                }

                if (value > 80)
                {
                    throw new Exception("Fugtværdi for høj");
                }

                if (value > 30 && value < 80)
                {
                    _fugt = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{(nameof(Id))}:{Id}, {(nameof(Fugt))}:{Fugt}, {(nameof(Temp))}:{Temp}, {(nameof(Navn))}:{Navn}";
        }

        //public override string ToString()
        //{
        //    return $"n";
        //}
    }
}
