namespace WebApiPerson.DTOs
{
    public class UpdatePasswordDTO
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
