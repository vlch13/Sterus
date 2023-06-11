namespace API.Errors
{
	public class ApiResponse
	{
		public ApiResponse(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}

		public int StatusCode { get; set; }
		public string Message { get; set; }

		private string GetDefaultMessageForStatusCode(int statusCode)
		{
			return statusCode switch
			{
				400 => "This bad request is",
				401 => "You Shall not pass!",
				404 => "Resource found, is not",
				500 => "Error, death, coffin dance",
				_ => null
			};
		}
	}
}