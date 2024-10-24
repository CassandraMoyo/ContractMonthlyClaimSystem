namespace ContractMonthlyClaimSystem
{
    public class testing_login_register_claim
    {
        //login method
        public string LogIn(string username, string password)
        {
            //temp for message
            string message = "";


            //check if the user is correct
            if (username.Equals("") && password.Equals("1234"))
            {
                //then assign user found to message
                message = "user found";
            }
            else
            {
                //then assign user found to message
                message = "user not found";

            }
            return message;

        }

        //register method
        public string Resgister(string username, string role, string password)

        {
            //check if the user is correct
            if (username.Equals("") && role.Equals("IC") && password.Length >= 8)
            {
                //then assign user found to message
                return "user found";
            }
            else
            {
                //then assign user found to message
                return "user not found";

            }


        }

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
