using versioning_manager.contracts.Services;

namespace versioning_manager.api.Controllers
{
    public class VersionRequest: IVersionRequest
    {
        public int ProductId { get; set; }
        public int? Major { get; set; }
        public int? Minor { get; set; }
    }
}
