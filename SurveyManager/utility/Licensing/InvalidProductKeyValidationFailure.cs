using Standard.Licensing.Validation;

namespace SurveyManager.utility.Licensing
{
    class InvalidProductKeyValidationFailure : IValidationFailure
    {
        public string Message { get => "The supplied product key was invalid for this product."; set { } }
        public string HowToResolve { get => "Purchase a new product key and recieve a new License File."; set { } }
    }
}
