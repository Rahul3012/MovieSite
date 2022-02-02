namespace Movie.Models.Contract
{
    public class MovieDetail
    {
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Plot { get; set; }
        public IList<int> ActorIds { get; set; }
        public IList<int> ProducerIds { get; set; }
        public byte[] Poster { get; set; } = new byte[0];
    }
}