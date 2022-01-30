namespace ProvaCandidato.Utils.Commons
{
    public static class Return
    {
        public static ReturnModel Success(string message)
        {
            return new ReturnModel(true, message);
        }

        public static ReturnModel<T> Success<T>(string message)
        {
            return new ReturnModel<T>(true, message);
        }

        public static ReturnModel<T> Success<T>(string message, T content)
        {
            return new ReturnModel<T>(true, message, content);
        }

        public static ReturnModel Fail(string message)
        {
            return new ReturnModel(false, message);
        }

        public static ReturnModel<T> Fail<T>(string message)
        {
            return new ReturnModel<T>(false, message);
        }

        public static ReturnModel<T> Fail<T>(string message, T content = default)
        {
            return new ReturnModel<T>(false, message, content);
        }
    }
}
