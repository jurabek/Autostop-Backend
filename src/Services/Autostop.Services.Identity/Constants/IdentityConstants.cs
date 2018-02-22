namespace Autostop.Services.Identity.Constants
{
    public struct IdentityConstants
    {
        public struct TokenRequest
        {
            public const string PhoneNumber = "phone_number";
            public const string Token = "token";
        }

        public struct GrantType
        {
            public const string VerifyPhoneNumber = "verify_phone_number_token";
        }
    }
}
