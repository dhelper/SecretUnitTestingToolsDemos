namespace StackExcangeNotifier
{
    public class User
    {

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public int Reputation { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (User)obj;

            return Id == other.Id &&
                DisplayName == other.DisplayName &&
                ImageUrl == other.ImageUrl &&
                Reputation == other.Reputation;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash *= 23 + Id.GetHashCode();
            hash *= 23 + DisplayName != null ? DisplayName.GetHashCode() : 0;
            hash *= 23 + ImageUrl != null ? ImageUrl.GetHashCode() : 0;
            hash *= 23 + Reputation.GetHashCode();

            return hash;
        }
    }
}
