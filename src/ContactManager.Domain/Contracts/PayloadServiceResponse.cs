namespace ContactManager.Domain.Contracts
{
    public class PayloadServiceResponse<T> : ServiceResponse where T : class
    {
        public T? Payload { get; protected set; }

        public PayloadServiceResponse() { }

        public static PayloadServiceResponse<T> Success(T payload) => new PayloadServiceResponse<T> { Payload = payload };
        public new static PayloadServiceResponse<T> Failure(params string[] errors)
        {
            var response = new PayloadServiceResponse<T>();
            response.Errors.AddRange(errors);
            return response;
        }
    }
}
