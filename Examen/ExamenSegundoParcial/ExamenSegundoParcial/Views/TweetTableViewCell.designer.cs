// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ExamenSegundoParcial.Views
{
	[Register ("TweetTableViewCell")]
	partial class TweetTableViewCell
	{
		[Outlet]
		UIKit.UIImageView ImgFavorited { get; set; }

		[Outlet]
		UIKit.UIImageView ImgRetweeted { get; set; }

		[Outlet]
		UIKit.UILabel lblFavorited { get; set; }

		[Outlet]
		UIKit.UILabel lblRetweeted { get; set; }

		[Outlet]
		UIKit.UILabel lblTweet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblTweet != null) {
				lblTweet.Dispose ();
				lblTweet = null;
			}

			if (lblFavorited != null) {
				lblFavorited.Dispose ();
				lblFavorited = null;
			}

			if (lblRetweeted != null) {
				lblRetweeted.Dispose ();
				lblRetweeted = null;
			}

			if (ImgFavorited != null) {
				ImgFavorited.Dispose ();
				ImgFavorited = null;
			}

			if (ImgRetweeted != null) {
				ImgRetweeted.Dispose ();
				ImgRetweeted = null;
			}
		}
	}
}
