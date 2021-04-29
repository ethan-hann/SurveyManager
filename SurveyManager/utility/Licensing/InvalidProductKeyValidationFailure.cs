using Standard.Licensing.Validation;

namespace SurveyManager.utility.Licensing
{
    class InvalidProductKeyValidationFailure : IValidationFailure
    {
        public string Message { get => "The supplied product key was invalid for this product."; set { } }
        public string HowToResolve { get => "Please purchase a new product key."; set { } }
    }
}
