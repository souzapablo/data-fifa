using DataFIFA.Core.Helpers;
using FluentValidation;
using System.Net;

namespace DataFIFA.Application.Validators.Shared
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        public List<ErrorMessage> ListErrors(T request)
        {
            var errors = new List<ErrorMessage>();

            var validation = Validate(request);

            if (validation.IsValid) return errors;

            foreach (var error in validation.Errors)
                errors.Add(new ErrorMessage(HttpStatusCode.BadRequest, error.ErrorMessage));

            return errors;
        }

    }
}
