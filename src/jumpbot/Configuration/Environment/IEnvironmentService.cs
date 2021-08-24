using Microsoft.Extensions.Configuration;

namespace jumpbot.Configuration.Environment
{
    // <summary>
    /// Environment service interface. This service provides IConfiguration instance.
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// This method returns IConfiguration instance.
        /// </summary>
        /// <returns></returns>
        IConfiguration Configuration { get; }
        /// <summary>
        /// Check mode is development.
        /// </summary>
        bool IsDevelopment { get; }
        /// Check mode is production.
        bool IsProduction { get; }
    }
}
