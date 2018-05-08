using System;
namespace ExamenSegundoParcial.Model
{
    public class Tweet
    {
         public ulong StatusID { get; set; }

         public string ScreenName { get; set; }

         public string Text { get; set; }

        public int Favorited
        {
            get;
            set;
        }
    }
}
