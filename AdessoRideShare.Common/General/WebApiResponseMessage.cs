namespace AdessoRideShare.Common.General
{
    public class WebApiResponseMessage<T>
    {
        public WebApiResponseMessage() => Header = new Header() { RetCode = 1, Message = "Success" };

        public Header Header { get; set; }
        public T Data { get; set; }
    }

    public class WebApiResponseMessage
    {
        public WebApiResponseMessage() =>Header = new Header() { RetCode = 1, Message = "Success" };

        public Header Header { get; set; }
    }

    public class Header
    {
        private int retCode;
        private string message;

        public Header()
        {
        }

        public Header(int retCode, string message)
        {
            this.RetCode = retCode;
            this.Message = message;
        }

        public int RetCode
        {
            get { return retCode; }
            set { retCode = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }

}
