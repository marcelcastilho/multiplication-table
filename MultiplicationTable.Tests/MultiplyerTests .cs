using MultiplicationTable.Models;
using System;
using Xunit;

namespace MultiplicationTable.Tests {
    public class MultiplyerTests {
        private readonly Multiplyer _multiplyer;

        public MultiplyerTests() {
            _multiplyer = new Multiplyer();
        }

        [Fact]
        public void Should_get_multiplication_table_10_x_10_by_default() {
            var actual = _multiplyer.GetMultiplicationTable();
            Assert.Equal(10, actual.Length);
            Assert.Equal(10, actual[0].Length);
        }

        [Fact]
        public void Should_get_multiplication_table_3_x_3() {
            var actual = _multiplyer.GetMultiplicationTable(3);
            Assert.Equal(3, actual.Length);
            Assert.Equal(3, actual[2].Length);
        }

        [Fact]
        public void Should_get_multiplication_table_15_x_15() {
            var actual = _multiplyer.GetMultiplicationTable(15);
            Assert.Equal(15, actual.Length);
            Assert.Equal(15, actual[10].Length);
        }

        [Fact]
        public void Should_multiply_table_10_x_10() {
            var actual = _multiplyer.GetMultiplicationTable();
            Assert.Equal("1", actual[0][0]);
            Assert.Equal("25", actual[4][4]);
            Assert.Equal("100", actual[9][9]);
        }

        [Fact]
        public void Should_multiply_table_3_x_3() {
            var actual = _multiplyer.GetMultiplicationTable(3);
            Assert.Equal("6", actual[2][1]);
            Assert.Equal("6", actual[1][2]);
            Assert.Equal("9", actual[2][2]);
        }

        [Fact]
        public void Should_multiply_table_15_x_15() {
            var actual = _multiplyer.GetMultiplicationTable(15);
            Assert.Equal("10", actual[0][9]);
            Assert.Equal("40", actual[9][3]);
            Assert.Equal("225", actual[14][14]);
        }

        [Fact]
        public void Should_not_get_multiplication_table_2_x_2() {
            Assert.Throws<ArgumentException>(() => _multiplyer.GetMultiplicationTable(2));
        }

        [Fact]
        public void Should_not_get_multiplication_table_16_x_16() {
            Assert.Throws<ArgumentException>(() => _multiplyer.GetMultiplicationTable(16));
        }

        [Fact]
        public void Should_return_binary() {
            var actual = _multiplyer.GetMultiplicationTable(10, MatrixBase.Binary);
            Assert.Equal("00000001", actual[0][0]);
            Assert.Equal("00011001", actual[4][4]);
            Assert.Equal("01100100", actual[9][9]);
        }

        
        [Fact]
        public void Should_return_hex() {
            var actual = _multiplyer.GetMultiplicationTable(15, MatrixBase.Hex);
            Assert.Equal("A", actual[0][9]);
            Assert.Equal("28", actual[9][3]);
            Assert.Equal("E1", actual[14][14]);
        }
    }
}
