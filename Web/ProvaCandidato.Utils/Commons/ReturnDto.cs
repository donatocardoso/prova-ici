namespace ProvaCandidato.Utils.Commons
{
    public class ReturnDto : IReturn
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public ReturnDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class ReturnDto<T> : IReturn<T>
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public T Content { get; }

        public ReturnDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Content = default;
        }

        public ReturnDto(bool isSuccess, string message, T content)
        {
            IsSuccess = isSuccess;
            Message = message;
            Content = content;
        }
    }
}
