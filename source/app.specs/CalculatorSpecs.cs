using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      
    }

    public class when_adding_two_numbers : concern
    {
      //Arrange
      Establish c = () =>
      {
        
      };

      //Act
      Because b = () =>
        result = sut.add(2, 3);

      //Assert
      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
    }

    public class when_attempting_to_ADd_a_negative_ToA_p_ositive   : concern
    {
      //Arrange
      Establish c = () =>
      {
        
      };

      //Act
      Because b = () =>
        spec.catch_exception(() => sut.add(-2, 3));

      //Assert
      It should_THrow_an_argument_Exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();

      static int result;
    }
  }
}