namespace BusinessLogic.Exceptions
{
    public class CorrespondentNotFoundException : Exception
    {
        public CorrespondentNotFoundException() { }
        public CorrespondentNotFoundException(string message) : base(message) { }
        public CorrespondentNotFoundException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
