using System;
using System.Data;

namespace app
{
    using System.Security;
    using System.Security.Principal;
    using System.Threading;

    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int firstNumber, int secondNumber)
        {
            if (firstNumber < 0 ||
              secondNumber < 0)
                throw new ArgumentException();

            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            return firstNumber + secondNumber;
        }

        public void shut_off()
        {
            IPrincipal userPrincipal = Thread.CurrentPrincipal;
            if (!userPrincipal.IsInRole("Admin"))
            {
                throw new SecurityException();
            }

        }
    }
}