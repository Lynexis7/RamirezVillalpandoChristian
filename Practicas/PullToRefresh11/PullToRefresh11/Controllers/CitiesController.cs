// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace PullToRefresh11
{
    public partial class CitiesController : UITableViewController
    {
        public CitiesController(IntPtr handle) : base(handle)
        {
        }


        #region Controller Life Cycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Mostrar las ciudades que tiene por default la aplicacion
        }

        #endregion

        #region TableView DataSource

        public override nint NumberOfSections(UITableView tableView)
        {
            return base.NumberOfSections(tableView);
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return base.RowsInSection(tableView, section);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            return base.GetCell(tableView, indexPath);
        }

        #endregion
    }
}
