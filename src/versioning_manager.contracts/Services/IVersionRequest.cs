namespace versioning_manager.contracts.Services
{
    public interface IVersionRequest
    {
        int ProductId { get; set; }
        int? Major {get; set;}

        int? Minor { get; set; }
    }

}
