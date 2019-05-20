using Microsoft.AspNetCore.Mvc;
using MultiplicationTable.Controllers;
using MultiplicationTable.Models;
using NSubstitute;
using System;
using Xunit;

namespace MultiplicationTable.Tests {
    public class MultiplicationTablesControllerTests {
        private readonly IMultiplyer _multiplyer;
        private readonly MultiplicationTablesController _controller;

        public MultiplicationTablesControllerTests() {
            _multiplyer = Substitute.For<IMultiplyer>();
            _controller = new MultiplicationTablesController(_multiplyer);
        }

        [Fact]
        public void Should_return_multiplication_table() {
            var expected = new string[][] {
                new string[3] { "1", "2", "3" },
                new string[3] { "5", "6", "7" },
                new string[3] { "1", "3", "2" }
            };
            _multiplyer.GetMultiplicationTable(Arg.Any<int>(), Arg.Any<MatrixBase>()).Returns(expected);
            var result = _controller.Get().Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void Should_return_bad_request_if_argument_exception() {
            _multiplyer.GetMultiplicationTable(20, Arg.Any<MatrixBase>()).Returns(x => {
                throw new ArgumentException();
            });
            var response = _controller.Get(20);
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
    }
}
