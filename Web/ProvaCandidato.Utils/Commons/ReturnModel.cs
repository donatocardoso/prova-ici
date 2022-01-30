namespace ProvaCandidato.Utils.Commons
{
    public class ReturnModel : IReturn
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ReturnModel()
        {
        }

        public ReturnModel(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class ReturnModel<T> : IReturn<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }

        public ReturnModel()
        {
        }

        public ReturnModel(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Content = default;
        }

        public ReturnModel(bool isSuccess, string message, T content)
        {
            IsSuccess = isSuccess;
            Message = message;
            Content = content;
        }
    }
}
