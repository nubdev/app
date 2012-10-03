using System;

namespace app
{
    using System.Data;

    public class Calculator
    {
        IDbConnection connection;
      public Calculator(IDbConnection dbConnection)
      {
          connection = dbConnection;
      }

      public int add(int firstNumber, int secondNumber)
    {
        if(firstNumber < 0 ||
            secondNumber < 0)
            throw new ArgumentException();

          connection.Open();
        return firstNumber + secondNumber;
    }
  }
}