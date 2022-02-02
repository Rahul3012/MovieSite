namespace Movie.Models.Contract
{
    using Movie.Common.Enum;

    public class CrewDetail
    {
        public PersonType Type { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
    }
}