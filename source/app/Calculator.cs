using System;

namespace app
{
  public class Calculator
  {
    public int add(int firstNumber, int secondNumber)
    {
        if(firstNumber < 0 ||
            secondNumber < 0)
            throw new ArgumentException();

        return firstNumber + secondNumber;
    }
  }
}