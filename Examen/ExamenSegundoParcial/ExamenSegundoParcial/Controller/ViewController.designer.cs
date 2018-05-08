// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ExamenSegundoParcial
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView TweetTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TweetTable != null) {
				TweetTable.Dispose ();
				TweetTable = null;
			}
		}
	}
}
