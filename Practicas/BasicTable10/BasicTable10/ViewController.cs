using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace BasicTable10
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
        #region Class Variables

        UITextField alertText = new UITextField();
        nint rowLimit = 0;
        UITableViewCell cell;
        List<int> lst;

        #endregion
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            tableView.DataSource = this;
            tableView.Delegate = this;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region UITableView DataSource

        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return rowLimit;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            cell = tableView.DequeueReusableCell("BasicTableViewCell", indexPath);
            //cell.TextLabel.Text = 
            return cell;
        }

        #endregion

        #region Internal Functionality

        void NumberOneAlert(int num) {
            UIAlertController alert = UIAlertController.Create("Choose the limit", "Please write the multiplication limit your number will have. Invalid numbers will be taken as a 0", UIAlertControllerStyle.Alert);
            alert.AddTextField((alertText) => {});

            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);
            var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, action => NumberOne(num));
            alert.AddAction(okayAction);
            alert.AddAction(cancelAction);
            PresentViewController(alert, true, null);
        }

        void NumberOne(int number)
        {
            //lst.Add();
            Console.WriteLine();
            rowLimit = nint.Parse(alertText.Text);
            cell.TextLabel.Text = "1";
        }

        #endregion

        #region User Interactions

        partial void btnAdd_Clicked(NSObject sender)
        {
            ShowAlert();
        }

        public void ShowAlert() {
            UIAlertController alert = UIAlertController.Create(null, "Choose a number.", UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("1", UIAlertActionStyle.Default, action => NumberOneAlert(1)));
            alert.AddAction(UIAlertAction.Create("2", UIAlertActionStyle.Default, action => NumberOneAlert(2)));
            alert.AddAction(UIAlertAction.Create("3", UIAlertActionStyle.Default, action => NumberOneAlert(3)));
            alert.AddAction(UIAlertAction.Create("4", UIAlertActionStyle.Default, action => NumberOneAlert(4)));
            alert.AddAction(UIAlertAction.Create("5", UIAlertActionStyle.Default, action => NumberOneAlert(5)));
            alert.AddAction(UIAlertAction.Create("6", UIAlertActionStyle.Default, action => NumberOneAlert(6)));
            alert.AddAction(UIAlertAction.Create("7", UIAlertActionStyle.Default, action => NumberOneAlert(7)));
            alert.AddAction(UIAlertAction.Create("8", UIAlertActionStyle.Default, action => NumberOneAlert(8)));
            alert.AddAction(UIAlertAction.Create("9", UIAlertActionStyle.Default, action => NumberOneAlert(9)));
            alert.AddAction(UIAlertAction.Create("10", UIAlertActionStyle.Default, action => NumberOneAlert(10)));
            alert.AddAction(UIAlertAction.Create("11", UIAlertActionStyle.Default, action => NumberOneAlert(11)));
            alert.AddAction(UIAlertAction.Create("12", UIAlertActionStyle.Default, action => NumberOneAlert(12)));
            alert.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, animated: true, completionHandler: null);
        }
        #endregion

    }
}
