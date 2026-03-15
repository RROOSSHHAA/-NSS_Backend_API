namespace NSS_API.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Year { get; set; }
        public string Caste { get; set; }
        public string BloodGroup { get; set; }
        public bool MyBharatRegistered { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Officer, Leader, Volunteer
        public int? ClassID { get; set; } 
        public string? VEC_No { get; set; }
        public bool IsVerified { get; set; }
        public string? OTPCode { get; set; }
    }
}