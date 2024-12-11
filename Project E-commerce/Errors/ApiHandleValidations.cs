namespace Project_E_commerce.Errors
{
    public class ApiHandleValidations : ApiResponse
    {
        public ApiHandleValidations() : base(400)
        {
        }



        public IEnumerable<string> Errors { get; set; }

    }
}
