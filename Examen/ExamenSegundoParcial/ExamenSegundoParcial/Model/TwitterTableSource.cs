using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace ExamenSegundoParcial.Model
{
    public class TwitterTableSource : UITableViewSource
    {
        const string CellIdentifier = "TweetCell";
        readonly List<Tweet> tweets;

        public TwitterTableSource(List<Tweet> tweets)
        {
            this.tweets = tweets;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return tweets.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
            cell.TextLabel.Text = tweets[indexPath.Row].ScreenName;
            cell.DetailTextLabel.Text = tweets[indexPath.Row].Text;
            return cell;
        }
    }
}
