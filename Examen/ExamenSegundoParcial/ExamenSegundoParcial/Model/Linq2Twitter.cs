using System;
using LinqToTwitter;

namespace ExamenSegundoParcial.Resources
{
    public class Linq2Twitter
    {
        #region Singleton

        static Lazy<Linq2Twitter> lazy = new Lazy<Linq2Twitter>(() => new Linq2Twitter());
        public Linq2Twitter SharedInstance
        {
            get => lazy.Value;
        }
        #endregion

        #region Events

        public EventHandler TweetsFetchedEventArgs;
        public EventHandler FetchedTweetsFailedEventArgs;

        #endregion


        #region Class Variables

        SingleUserAuthorizer auth;

        #endregion

        #region Constructor

        Linq2Twitter()
        {
            auth = new SingleUserAuthorizer()
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "fPU8v5PXMSeIcLYnDe6BGJ2c8",
                    ConsumerSecret = "w1hFnHo2H5FEAfr5qRuZyLrctkDvMq9wkMUOe0SJjUr7L1TPGm"
                },
            };
        }

        #endregion

        #region Internal Functionality



        #endregion

    }

    public class TweetsFetchedEventArgs : EventArgs {
        public object Tweets
        {
            get;
            set;
        }

        public TweetsFetchedEventArgs(object tweets) {
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

        public FetchedTweetsFailedEventArgs(string errorMessage) {
            Message = errorMessage;
        }
    }
}
