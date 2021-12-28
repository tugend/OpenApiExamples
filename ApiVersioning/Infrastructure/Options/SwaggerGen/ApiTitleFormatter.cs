using NJsonSchema;

namespace ApiVersioning.Infrastructure.Options.SwaggerGen
{
    public static class TitleFormatter
    {
        /// <summary>
        /// Since the group name is used for both generating the url (which is requested in a case sensitive manner),
        /// and for display, this method takes the machine/url friendly name and formats it for display.
        /// </summary>
        public static string FormatSwaggerGroupNameForDisplay(string? name)
        {
            return ConversionUtilities.ConvertToUpperCamelCase(name!, false).Replace("_", " ");
        }
    }
}