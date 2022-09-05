//using FluentValidation;

//namespace DataAccess.Models.Validators
//{
//    public class TrackValidator : AbstractValidator<Track>
//    {
//        public TrackValidator()
//        {
//            RuleFor(g => g.Name)
//                .NotNull()
//                .MaximumLength(100)
//                .Matches(@"[A-Z]\w*").WithMessage("Property {PropertyName} must begin with upper case letter.");

//            RuleFor(g => g.Rating).InclusiveBetween(1, 10).WithMessage("{PropertyName} must be from 1 to 10");
//        }
//    }
//}

//[Required, StringLength(100, MinimumLength = 2)]
//[RegularExpression(@"$[A-Z]\w*^")]
