namespace qPatterns.Core.Configuration
{
    public interface IApplicationSettings
    {
        int NumberOfResultsPerPage {get; }
       
        string LoggerName { get; }

        string RpxApiKey { get;  }

        string PayPalBusinessEmail { get; }
        string PayPalPaymentPostToUrl { get; }
    }
}
