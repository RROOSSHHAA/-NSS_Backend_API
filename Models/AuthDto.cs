namespace NSS_API.Models  // <--- Ye naam project folder se match hona chahiye
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? LeaderID { get; set; }
        public string PhoneNumber { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Year { get; set; }
        public string Caste { get; set; }
        public string BloodGroup { get; set; }
        public bool MyBharatRegistered { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}