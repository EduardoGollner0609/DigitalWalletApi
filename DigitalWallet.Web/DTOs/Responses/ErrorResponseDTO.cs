namespace DigitalWallet.Web.DTOs.Responses
{
    public class ErrorResponseDTO
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public string Moment { get; private set; }

        public ErrorResponseDTO(int statusCode, string message, DateTime moment)
        {
            StatusCode = statusCode;
            Message = message;
            Moment = moment.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
