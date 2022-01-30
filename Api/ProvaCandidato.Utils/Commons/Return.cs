namespace ProvaCandidato.Utils.Commons
{
    public static class Return
    {
        public static ReturnDto Success(string message)
        {
            return new ReturnDto(true, message);
        }

        public static ReturnDto<T> Success<T>(string message)
        {
            return new ReturnDto<T>(true, message);
        }

        public static ReturnDto<T> Success<T>(string message, T content)
        {
            return new ReturnDto<T>(true, message, content);
        }

        public static ReturnDto Fail(string message)
        {
            return new ReturnDto(false, message);
        }

        public static ReturnDto<T> Fail<T>(string message)
        {
            return new ReturnDto<T>(false, message);
        }

        public static ReturnDto<T> Fail<T>(string message, T content = default)
        {
            return new ReturnDto<T>(false, message, content);
        }
    }
}
