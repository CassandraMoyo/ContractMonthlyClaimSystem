namespace ContractMonthlyClaimSystem
{
    public class testing_login_register_claim
    {
        //register
        public string Register(string name, string surname, string contact, string address, string email, string password, string role)
        {
            // Check if the user input is correct
            if (email.Equals("admin@gmail.com") && role.Equals("IC") && password.Length < 2)
            {
                // Assign user found to message
                return "user found";
            }
            else
            {
                // Assign user not found to message
                return "user not found";
            }
        }
      //login method
      public string LogIn(string username, string password)
        {

            // Temp for message
            string message = "";

            // Check if the user is correct
            if (username.Equals("admin@gmail.com") && password.Equals("1234"))
            {
                // Assign user found to message
                message = "user found";
            }
            else
            {
                // Assign user not found to message
                message = "user not found";
            }
            return message;
        }

        //claim method
       

        public string Claim (string qualification, string module, string group, string date, string hours_work, string rate, string file)
        {
            if(qualification != "")
            {
                return "sumbitted";
            }
            else
            {
                return "not submitted";
            }
        }
    }
}
