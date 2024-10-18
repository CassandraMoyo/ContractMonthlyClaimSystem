namespace ContractMonthlyClaimSystem.Models
{
    public class Register
    {
        //getters and setters 
        public string Name {  get; set; } = "";
        public string Surname { get; set; } = "";
        public string Contact { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Passoward { get; set; } = "";
        public string Role { get; set; } = "";

        //connection string clas
        connection connect = new connection();

        public string insert_users(string Name,string emails,string roles,string password)
        {
            return " ";
        }
    }
}
