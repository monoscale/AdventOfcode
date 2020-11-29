using Aoc2019.Intcode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Tests.Intcode {

    [TestFixture]
    public class IntcodeProgramTest {

        private IntcodeProgram intcodeProgram;

        [Test]
        public void Day2Part1Example() {
            intcodeProgram = new IntcodeProgram("1,9,10,3,2,3,11,0,99,30,40,50");
            intcodeProgram.Execute();
            Assert.AreEqual(3500, intcodeProgram[0]);
        }


        [Test]
        public void Day5Part1Example1() {
            intcodeProgram = new IntcodeProgram("3,0,4,0,99");
            intcodeProgram.AddToInput(1);
            intcodeProgram.Execute();
            Assert.AreEqual(1, intcodeProgram.Outputs[0]);
        }

        [Test]
        public void Day5Part1Example2() {
            intcodeProgram = new IntcodeProgram("1002,4,3,4,33");
            intcodeProgram.Execute();
            Assert.AreEqual(99, intcodeProgram[4]);
        }


        [Test]
        public void Day5Part2Example1() {
            intcodeProgram = new IntcodeProgram("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9");
            intcodeProgram.AddToInput(0);
            intcodeProgram.Execute();
            Assert.AreEqual(0, intcodeProgram.Outputs[0]);
        }

        [Test]
        public void Day5Part2Example2() {
            intcodeProgram = new IntcodeProgram("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9");
            intcodeProgram.AddToInput(500); // 500 arbitrary value
            intcodeProgram.Execute();
            Assert.AreEqual(1, intcodeProgram.Outputs[0]);
        }

        [Test]
        public void Day5Part2Example3() {
            intcodeProgram = new IntcodeProgram("3,3,1105,-1,9,1101,0,0,12,4,12,99,1");
            intcodeProgram.AddToInput(0);
            intcodeProgram.Execute();
            Assert.AreEqual(0, intcodeProgram.Outputs[0]);
        }

        [Test]
        public void Day5Part2Example4() {
            intcodeProgram = new IntcodeProgram("3,3,1105,-1,9,1101,0,0,12,4,12,99,1");
            intcodeProgram.AddToInput(500); // 500 arbitrary value
            intcodeProgram.Execute();
            Assert.AreEqual(1, intcodeProgram.Outputs[0]);
        }


        /// <summary>
        /// This example program uses an input instruction to ask for a single number. 
        /// The program will then output 999 if the input value is below 8, 
        /// output 1000 if the input value is equal to 8, 
        /// or output 1001 if the input value is greater than 8.
        /// </summary>
        [Test]
        [TestCase(4, 999)]
        [TestCase(8,1000)]
        [TestCase(10,1001)]
        public void Day5Part2Example5(int input, int expected) {
            intcodeProgram = new IntcodeProgram("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99");
            intcodeProgram.AddToInput(input);
            intcodeProgram.Execute();
            Assert.AreEqual(expected, intcodeProgram.Outputs[0]);
        }

    }
}

