namespace ContactManager.Domain.Contracts
{
    public class ServiceResponse
    {
        public List<string> Errors { get; protected set; } = new();
        public bool IsSuccessful => Errors.Count == 0;
        protected ServiceResponse() { }

        public static ServiceResponse Failure(params string[] errors)
        {
            var response = new ServiceResponse();
            response.Errors.AddRange(errors);
            return response;
        }
        public static ServiceResponse Success() => new ServiceResponse();
    }
}
