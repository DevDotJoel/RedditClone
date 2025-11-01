using FluentValidation;

namespace Modules.Posts.Application.Posts.Commands.Create
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MinimumLength(3)
                .WithMessage("Title must be at least 3 characters")
                .MaximumLength(300)
                .WithMessage("Title cannot exceed 300 characters");

            RuleFor(x => x.Content)
                .MaximumLength(40000)
                .WithMessage("Content cannot exceed 40,000 characters")
                .When(x => !string.IsNullOrEmpty(x.Content));
        }
    }
}
