using InputKit.Shared.Validations;

namespace EwalletMobileApp.Validations
{
    public class MustBeLessThanAvailable : IValidation
    {
        public string Message => $"Price must be Less than {AvailableAmount}";
        public double AvailableAmount { get; set; }
        public bool Validate(object value)
        {
            if (value is double input)
            {
                return input <= AvailableAmount;
            }

            return false;
        }
    }
}
