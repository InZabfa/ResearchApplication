namespace SharedObjects.Response
{
    public class Response
    {
        public Response() { }

        public Response(string Message) => this.Message = Message;

        public string Message { get; set; }
    }
}
