namespace LibraryManagementAPI.Contracts.V1.Requests
{
    public class CreateBookRequest
    {
        public string Name { get; set; }
        public double Credits { get; set; }
        public int Quantities { get; set; }
    }
}
