using System.Globalization;

namespace MyRecipeBook.API.Middleware
{
    public class CultureMiddleware
    {

        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault().ToString();

            var cultureInfo = new CultureInfo(requestedCulture);

            if (string.IsNullOrEmpty(requestedCulture) == false && supportedLanguages.Any(c => c.Name.Equals(requestedCulture))) { 
                cultureInfo = new CultureInfo("en");
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
