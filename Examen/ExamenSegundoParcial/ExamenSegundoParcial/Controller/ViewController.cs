using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamenSegundoParcial.Model;
using ExamenSegundoParcial.Resources;
using ExamenSegundoParcial.Views;
using Foundation;
using LinqToTwitter;
using UIKit;

namespace ExamenSegundoParcial
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, IUISearchResultsUpdating
    {

        #region Class variables

        UISearchController searchController;
        List<Status> tweets;
        Linq2Twitter lq;

        #endregion

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            InitializeComponents();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        #region User Interactions



        #endregion

        #region UITableView data Source

        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var tweet = tweets[indexPath.Row];
            var cell = tableView.DequeueReusableCell(TweetTableViewCell.Key, indexPath) as TweetTableViewCell;
            cell.Tweet = tweet.FullText;
            cell.Favorited = tweet.Favorited.ToString() ?? "0";
            cell.Retweeted = tweet.Retweeted.ToString();
            return cell;
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return 20;
        }

        #endregion



        #region Internal Functionality

        void InitializeComponents()
        {
            lq.SharedInstance.FetchedTweetsFailedEvent += SharedInstance_FetchedTweetsFailedEvent;
            lq.SharedInstance.TweetsFetchedEvent += SharedInstance_TweetsFetchedEvent;

            searchController = new UISearchController(searchResultsController: null)
            {
                SearchResultsUpdater = this,
                DimsBackgroundDuringPresentation = false
            };
            TweetTable.DataSource = this;
            TweetTable.Delegate = this;
            TweetTable.TableHeaderView = searchController.SearchBar;
            //TweetTable.RowHeight = UITableView.
        }

        #endregion


        #region Search Results Updating

        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            lq.SharedInstance.SearchTweets(searchController.SearchBar.Text);
        }

        #endregion

        #region Linq Events

        void SharedInstance_FetchedTweetsFailedEvent(object sender, Resources.FetchedTweetsFailedEventArgs e)
        {

        }

        void SharedInstance_TweetsFetchedEvent(object sender, Resources.TweetsFetchedEventArgs e)
        {

        }

        #endregion


    }
}
