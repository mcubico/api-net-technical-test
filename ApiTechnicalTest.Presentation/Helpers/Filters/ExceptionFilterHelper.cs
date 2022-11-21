using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiTechnicalTest.Presentation.Helpers.Filters
{
    /// <summary>
    /// Filtro usado para capturar las excepciones no controladas y darles manejo
    /// ---
    /// Filter used to capture uncontrolled exceptions and give them handling
    /// </summary>
    public class ExceptionFilterHelper : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilterHelper> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ExceptionFilterHelper(ILogger<ExceptionFilterHelper> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Evento en el que se gestionan las excepciones no controladas
        /// ---
        /// Event used to managment uncontrolated exceptions
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}
