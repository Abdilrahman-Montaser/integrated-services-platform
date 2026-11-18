namespace TadweerHub.DAL.Entities
{
    public class RegistrationDocument
    {
        public int DocumentId { get; set; }
        public int RequestId { get; set; }
        public string? DocType { get; set; }
        public string? FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }

        public RegistrationRequest? Request { get; set; }
    }
}
