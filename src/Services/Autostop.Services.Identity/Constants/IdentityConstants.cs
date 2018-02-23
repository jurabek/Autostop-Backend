namespace Autostop.Services.Identity.Constants
{
    public struct IdentityConstants
    {
        public struct TokenRequest
        {
            public const string PhoneNumber = "phone_number";
            public const string Token = "verification_token";
            public const string ResendToken = "resend_token";
        }

        public struct GrantType
        {
            public const string VerifyPhoneNumber = "verify_phone_number_token";
        }
    }
}
