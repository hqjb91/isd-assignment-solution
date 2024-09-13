namespace Application.Common;

public static class ApplicationConstants
{
    // Validation Error Messages
    public const string FieldRequiredError = "{0} is required.";
    public const string MaximumLengthError = "Maximum Length is {0}.";
    public const string InvalidFormatError = "Invalid Format : Expected {0}.";

    // Validation Regex Rules
    public const string AlphabeticalRegex = "^[a-zA-Z\\s]+$";
}
