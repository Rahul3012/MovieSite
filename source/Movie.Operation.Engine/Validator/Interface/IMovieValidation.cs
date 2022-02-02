namespace Movie.Operation.Engine.Validator.Interface
{
    using Movie.Models.Contract;
    using System.Collections.Generic;

    public interface IMovieValidation
    {
        public IList<string> ValidateRequest(MovieDetail movieDetail);
    }
}
