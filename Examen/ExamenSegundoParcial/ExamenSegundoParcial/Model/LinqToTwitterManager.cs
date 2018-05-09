using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LinqToTwitter;

namespace ExamenSegundoParcial.Model
{
    public class LinqToTwitterManager
    {
        #region Singleton

        static Lazy<LinqToTwitterManager> lazy = new Lazy<LinqToTwitterManager>(() => new LinqToTwitterManager());
        public static LinqToTwitterManager SharedInstance
        {
            get => lazy.Value;
        }
        #endregion

        #region Events

        public event EventHandler<TweetsFetchedEventArgs> TweetsFetchedEvent;
        public event EventHandler<FetchedTweetsFailedEventArgs> FetchedTweetsFailedEvent;

        #endregion


        #region Class Variables

        SingleUserAuthorizer auth;
        TwitterContext twitterContext;
        CancellationTokenSource cancellationTokenSource;

        #endregion

        #region Constructor

        LinqToTwitterManager()
        {
            auth = new SingleUserAuthorizer()
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "fPU8v5PXMSeIcLYnDe6BGJ2c8",
                    ConsumerSecret = "w1hFnHo2H5FEAfr5qRuZyLrctkDvMq9wkMUOe0SJjUr7L1TPGm"
                },
            };
            twitterContext = new TwitterContext(auth);
            cancellationTokenSource = new CancellationTokenSource();
        }

        #endregion

        #region Internal Functionality

        async Task<List<Status>> SearchTweetsAsync(string query, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace((query)))
                return null;

            cancellationToken.ThrowIfCancellationRequested();

            Search searchResponse =
                await
                (from search in twitterContext.Search
                 where search.Type == SearchType.Search &&
                       search.Query == query &&
                       search.IncludeEntities == true &&
                       search.TweetMode == TweetMode.Extended
                 select search)
                .SingleOrDefaultAsync();

            cancellationToken.ThrowIfCancellationRequested();
            return searchResponse?.Statuses;
        }

        #endregion

        #region Public Functionality

        public void SearchTweets(string query)
        {
            if (cancellationTokenSource.IsCancellationRequested)
                cancellationTokenSource.Cancel();

            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            Task.Factory.StartNew(async () =>
            {
                try
                {
                    var tweets = await SearchTweetsAsync(query, cancellationToken);

                    var e = new TweetsFetchedEventArgs(tweets);
                    TweetsFetchedEvent?.Invoke(this, e);
                }
                catch (Exception ex)
                {
                    var e = new FetchedTweetsFailedEventArgs(ex.Message);
                    FetchedTweetsFailedEvent?.Invoke(this, e);
                }
            });
        }

        #endregion

        public class TweetsFetchedEventArgs : EventArgs
        {
            public List<Status> Tweets
            {
                get;
                set;
            }

            public TweetsFetchedEventArgs(List<Status> tweets)
            {
                Tweets = tweets;
            }
        }

        public class FetchedTweetsFailedEventArgs : EventArgs
        {
            public string Message
            {
                get;
                set;
            }

            public FetchedTweetsFailedEventArgs(string errorMessage)
            {
                Message = errorMessage;
            }
        }
    }
}
