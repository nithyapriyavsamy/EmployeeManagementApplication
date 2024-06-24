namespace EmployeeManagement.ErrorMessages
{
    public class Messages
    {
        public List<string> messages=new List<string>();
        public Messages()
        {
            messages=new List<string>() { 
                "Registered Successfully",
                "Employee Not found",
                "Invalid Username or password",
                "Unable to Register the User",
                "SQL error try again",
                "Unable to Update the Employee",
                "Unable to Delete the Employee",
                "Unable to Change status"
            };
        }
    }
}
