namespace Movie.Models.SQL
{
    public class MovieDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Producers { get; set; }
        public byte[] Poster { get; set; }

    }
}