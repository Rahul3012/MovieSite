namespace Movie.Operation.Engine.Validator.Class
{
    using FluentValidation;
    using Movie.Models.Contract;
    using Movie.Operation.Engine.Validator.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieValidation : AbstractValidator<MovieDetail>, IMovieValidation
    {
        public MovieValidation()
        {
            RuleFor(x => x).NotNull().WithMessage("Movie details cannot be null");
            RuleFor(x => x.Name).NotNull().WithMessage("Movie name cannot be null");
            RuleFor(x => x.ReleasedDate).NotNull().WithMessage("Movie released date cannot be null");
            RuleFor(x => x.ActorIds).NotNull().WithMessage("Movie actors cannot be null");
            RuleFor(x => x.ProducerIds).NotNull().WithMessage("Movie producers cannot be null");
        }
        public IList<string> ValidateRequest(MovieDetail movieDetail)
        {
            var result = Validate(movieDetail);
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList<string>();
            return errors;
        }
    }
}
