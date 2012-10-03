using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    public class CalculatorSpecs
    {
        [Subject(typeof(Calculator))]
        public abstract class concern : Observes<Calculator>
        {

        }

        public class when_created : concern
        {
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
            };

            It should_not_leverage_its_connection_at_all = () =>
            {
                connection.never_received(x => x.Open());
                connection.never_received(x => x.CreateCommand());
            };

            static IDbConnection connection;

        }

        public class when_turning_off_the_calculator : concern
        {
            public class and_they_are_not_in_the_right_security_role
            {
                Establish c = () =>
                {
                    the_principal = fake.an<IPrincipal>();

                    the_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                    spec.change(() => Thread.CurrentPrincipal).to(the_principal);
                };

                Because of = () =>
                    {
                        spec.catch_exception(() => sut.shut_off());
                    };

                It should_throw_a_security_exception = () =>
                  spec.exception_thrown.ShouldBeAn<SecurityException>();

                static IPrincipal the_principal;
            }
        }
        public class when_adding_two_numbers : concern
        {
            //Arrange
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
                command = fake.an<IDbCommand>();

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            //Act
            Because b = () =>
              result = sut.add(2, 3);

            //Assert
            It should_return_the_sum = () =>
              result.ShouldEqual(5);

            It should_open_a_Connection_to_The_db = () =>
              connection.received(x => x.Open());

            It should_runa_QU_ery = () =>
              command.received(x => x.ExecuteNonQuery());

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        public class when_attempting_to_add_a_negative_to_a_positive : concern
        {
            //Arrange
            Establish c = () =>
            {

            };

            //Act
            Because b = () =>
              spec.catch_exception(() => sut.add(-2, 3));

            //Assert
            It should_throw_an_argument_exception = () =>
              spec.exception_thrown.ShouldBeAn<ArgumentException>();

            static int result;
        }
    }
}