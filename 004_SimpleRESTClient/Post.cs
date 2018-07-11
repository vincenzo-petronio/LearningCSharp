using System.Runtime.Serialization;

namespace _004_SimpleRESTClient
{
    [DataContract]
    class Post
    {
        [DataMember(Name = "userId")]
        public string UserId { get; internal set; }

        [DataMember(Name = "id")]
        public int Id { get; internal set; }

        [DataMember(Name = "title")]
        public string Title { get; internal set; }

        [DataMember(Name = "body")]
        public string Body { get; internal set; }

    }
}
