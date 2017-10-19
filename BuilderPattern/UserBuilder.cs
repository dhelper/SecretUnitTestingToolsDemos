using StackExcangeNotifier;

namespace BuilderPattern
{
    class UserBuilder
    {
        private int _id, _reputation;
        private string _displayName, _imageUrl;

        public UserBuilder()
        {
            _id = 1;
            _displayName = "dummy";
            _imageUrl = "http://dummy.jpg";
        }

        public UserBuilder WithName(string displayName)
        {
            _displayName = displayName;

            return this;
        }

        public UserBuilder WithReputation(int reputation)
        {
            _reputation = reputation;

            return this;
        }

        public User Build()
        {
            return new User
            {
                Id = _id,
                DisplayName = _displayName,
                ImageUrl = _imageUrl,
                Reputation = _reputation
            };
        }
    }
}
