namespace OAuth
{
    /// <summary>
    /// Describes a url parameter of the format parameter=value
    /// </summary>
    public class UrlParameter
    {
        public UrlParameter(KnownOAuthParameters name, string value)
        {
            Name = name;
            Value = value;
        }
        public KnownOAuthParameters Name { get; private set; }
        public string Value { get; private set; }
    }

    /// <summary>
    /// Possible parameter types for the url
    /// </summary>
    public enum KnownOAuthParameters
    {
        oauth_version,
        oauth_consumer_key,
        oauth_timestamp,
        oauth_nonce,
        oauth_token,
        oauth_token_secret,
        oauth_signature,
        oauth_signature_method,
        oauth_verifier,
        oauth_callback,
        oauth_expires_in,
        oauth_session_handle,
        oauth_callback_confirmed,
        oauth_authorization_expires_in,
        xoauth_yahoo_guid,
        xoauth_request_auth_url,
        xoauth_lang_pref,
        status,
    }


}
