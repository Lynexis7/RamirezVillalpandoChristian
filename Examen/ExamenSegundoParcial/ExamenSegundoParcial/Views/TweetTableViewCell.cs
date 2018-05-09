using System;

using Foundation;
using UIKit;

namespace ExamenSegundoParcial.Views
{
    public partial class TweetTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("TweetTableViewCell");

        public string Tweet
        {
            get => lblTweet.Text;
            set => lblTweet.Text = value;
        }

        public string Favorited {
            get => lblFavorited.Text;
            set => lblFavorited.Text = value;
        }

        public string Retweeted
        {
            get => lblRetweeted.Text;
            set => lblRetweeted.Text = value;
        }

        protected TweetTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
