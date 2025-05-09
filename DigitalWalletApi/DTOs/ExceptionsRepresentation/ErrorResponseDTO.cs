namespace DigitalWalletApi.DTOs.ExceptionsRepresentation
{
    public class ErrorResponseDTO
    {
        public int Code { get; private set; }
        public string Message { get; private set; }
        public DateTime Moment { get; private set; }

        public ErrorResponseDTO() { }

        public ErrorResponseDTO(int code, string message)
        {
            Code = code;
            Message = message;
            Moment = DateTime.Now;
        }
    }
}
