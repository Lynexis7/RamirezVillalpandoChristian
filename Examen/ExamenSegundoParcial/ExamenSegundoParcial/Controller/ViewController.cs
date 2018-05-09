using System;
using System.Collections.Generic;
using ExamenSegundoParcial.Model;
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

        #region Internal Functionality

        void InitializeComponents()
        {

            tweets = new List<Status>();
            LinqToTwitterManager.SharedInstance.TweetsFetchedEvent += SharedInstance_TweetsFetchedEvent1;
            LinqToTwitterManager.SharedInstance.FetchedTweetsFailedEvent += SharedInstance_FetchedTweetsFailedEvent1;

            searchController = new UISearchController(searchResultsController: null)
            {
                SearchResultsUpdater = this,
                DimsBackgroundDuringPresentation = false
            };
            TweetTableView.DataSource = this;
            TweetTableView.Delegate = this;
            TweetTableView.TableHeaderView = searchController.SearchBar;
            TweetTableView.RowHeight = UITableView.AutomaticDimension;
            TweetTableView.EstimatedRowHeight = 50;
        }

        #endregion


        #region UITableView data Source

        [Export("numberOfSectionsInTableView:")]
        public  nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public  UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            try
            {
                if (tweets.Count > 0)
                {
                    var tweet = tweets[indexPath.Row];
                    var cell = tableView.DequeueReusableCell(TweetTableViewCell.Key, indexPath) as TweetTableViewCell;
                    cell.Tweet = tweet.FullText;
                    cell.Favorited = tweet.FavoriteCount.ToString() ?? "0";
                    cell.Retweeted = tweet.RetweetCount.ToString();
                    return cell;
                }
                else
                {
                    var tweet = tweets[indexPath.Row];
                    var cell = tableView.DequeueReusableCell(TweetTableViewCell.Key, indexPath) as TweetTableViewCell;
                    cell.Tweet = "";
                    cell.Favorited = "";
                    cell.Retweeted = "";
                    return cell;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public  nint RowsInSection(UITableView tableView, nint section)
        {
            try
            {
                return tweets.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }

        #endregion


        #region Search Results Updating

        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            if(searchController.SearchBar.Text != "")
                LinqToTwitterManager.SharedInstance.SearchTweets(searchController.SearchBar.Text);
        }

        #endregion

        #region Linq Events

        void SharedInstance_TweetsFetchedEvent1(object sender, Model.LinqToTwitterManager.TweetsFetchedEventArgs e)
        {
            tweets = e.Tweets;
            InvokeOnMainThread(() => TweetTableView.ReloadData());
        }

        void SharedInstance_FetchedTweetsFailedEvent1(object sender, Model.LinqToTwitterManager.FetchedTweetsFailedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        #endregion

    }
}
