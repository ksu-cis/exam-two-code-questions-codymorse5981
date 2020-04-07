/* Author: Cody Morse
 * Class: CobblerUnitTest.xaml.cs
 * Description: Handles CobblerUnitTest class 
  */

using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// Ensures class implements INotifyChangedProperty
        /// </summary>
        [Fact]
        public void CobblerShouldImplrementINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }

        /// <summary>
        /// Testing WithIceCream property for invocation of PropertyChanged
        /// </summary>
        [Fact]
        public void ChangingIceCreamPropertyShouldInvokePropertyChangedForIceCream()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "WithIceCream", () =>
            {
                cobbler.WithIceCream = true;
            });
        }

        /// <summary>
        /// Testing WithIceCream property for invocation of PropertyChanged
        /// </summary>
        [Fact]
        public void ChangingIceCreamPropertyShouldInvokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Price", () =>
            {
                cobbler.WithIceCream = true;
            });
        }

        /// <summary>
        /// Testing WithIceCream property for invocation of PropertyChanged for special instructions
        /// </summary>
        [Fact]
        public void ChangingIceCreamPropertyShouldInvokePropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () =>
            {
                cobbler.WithIceCream = true;
            });
        }

        /// <summary>
        /// Tests property changed for fruit filling
        /// </summary>
        /// <param name="filling">Fruitfilling property</param>
        [Theory]
        [InlineData(FruitFilling.Peach)]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        public void CobblerFruitChangeShouldNotifyPropertyChanged(FruitFilling filling)
        {
            Cobbler cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Fruit", () =>
            {
                cobbler.Fruit = filling;
            });
        }
    }
}
