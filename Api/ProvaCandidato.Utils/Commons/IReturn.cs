namespace ProvaCandidato.Utils.Commons
{
    public interface IReturn
    {
        bool IsSuccess
        {
            get;
        }

        string Message
        {
            get;
        }
    }

    public interface IReturn<T>
    {
        bool IsSuccess
        {
            get;
        }

        string Message
        {
            get;
        }

        T Content
        {
            get;
        }
    }
}
