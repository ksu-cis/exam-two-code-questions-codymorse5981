/* Author: Cody Morse
 * Class: Cobbler.cs
 * Description: Handles Cobbler class 
  */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Event handler for properties changing.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        private FruitFilling fruit;

        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public FruitFilling Fruit
        {
            get { return fruit; }

            set
            {
                fruit = value;
                NotifyOfPropertyChange("Fruit");
            }
        }

        private bool withIceCream = true;

        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get { return withIceCream; }

            set
            {
                withIceCream = value;
                NotifyOfPropertyChange("WithIceCream");
                NotifyOfPropertyChange("Price");
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if (WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        /// <summary>
        /// Helper method for notifying changed
        /// </summary>
        /// <param name="propertyName">Property for notifying</param>
        private protected void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }

        /// <summary>
        /// Creates a string for specific item and contents
        /// </summary>
        /// <returns>Item string</returns>
        public override string ToString()
        {
            if (WithIceCream)
            {
                return Fruit + " Cobber: With Ice Cream";
            }
            else
            {
                return Fruit + " Cobber: Without Ice Cream";
            }

        }
    }
}
