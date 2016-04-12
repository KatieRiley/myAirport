/*
*  Kathryn Hoskins
*  
*
* Develop a Windows form application that enables the
*   user to enter values for airport name, Celsius temperature,
*   and elevation. Have a multi line message box that outputs 
*   the airports name, celsius temperature, fahrenheit temperature, 
*   and elevation 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIT_180_Lab5_Hoskins
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void recordDataButton_Click(object sender, EventArgs e)
        {

            //int[] boo = new int [10]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Airport myAirport;              
            string myAirportName = " ";
            double myCelsiusTemp = 0.0;
            double myAirportElev = 0.0;

            //max values used for error checking
            double tempMax = 50;    
            double tempMin = -50;
            double elevationMax = 12000;
            double elevationMin = -300;

            //the message that will be displayed in the message box
            string message = " ";
            
            //setting the variables with values from the correct textbox
            myAirportName = airportName.Text;
            myCelsiusTemp = Convert.ToDouble(tempTextBox.Text);
            myAirportElev = Convert.ToDouble(elevationTextBox.Text);

            //error checking to set the message box to either display an error message telling 
            //the user what went wrong or displaying the correct information
            if (myAirportName == "")
            {
                message = "That is not a valid Airport name";
            }
            else if (myCelsiusTemp < tempMin || myCelsiusTemp > tempMax)
            {
                message = "That is not a valid temperature \r\nThe temperature must be above -50c and below 50c";
            }
            else if (myAirportElev < elevationMin || myAirportElev > elevationMax)
            {
                message = "That is not a valid elevation \r\nThe elevation needs to be above -300 feet and below 12000 feet";
            }
            //all the inputs were valid so now we can set up our airport object and
            //set the message 
            else
            {
                myAirport = new Airport(myAirportName, myCelsiusTemp, myAirportElev);

                message = "The Airports name is: " + myAirport.getAirportName() + "\r\n";
                message += "The Airports celsius temperature is: " + Convert.ToString( myAirport.getCelsiusTem()) + "\r\n";
                message += "The Airports fahrenheit temperature is: " + Convert.ToString(myAirport.celsiusToFahrenheit()) + "\r\n";
                message += "The Airports elevation is: " + Convert.ToString(myAirport.getElevation()) + "\r\n";

            }
            //showing either an error message or the correct output depending on the user input
            MessageBox.Show(message);
        }
        
        //quits the application
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Control myControl = new Control();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


    public class Airport {
        private string airportName;
        private double celsiusTemp;
        private double airportElevation;

        /* public Airport(string theName, double theTemp, double theElevation)
        *   constructor
        *   Parameters: string - the name of the airport
        *               double - the teprature in celsius 
        *               double - the elevation               
        *   sets all variables
        */
        public Airport(string theName, double theTemp, double theElevation)
        {
            airportName = theName;
            celsiusTemp = theTemp;
            airportElevation = theElevation;
        }

        /* public double celsiusToFahrenheit()
        *   Parameters: NONE               
        *   Returns:    double - the temprature in fahrenheit
        */
        public double celsiusToFahrenheit()
        {
            double fahrenheitTemp = 0.0;

            celsiusTemp *= 1.8;
            fahrenheitTemp = celsiusTemp + 32;

            return fahrenheitTemp;
        }

        /*the getter for the class so we can output into the message box*/
        public string getAirportName()
        {
            return airportName;
        }

        public double getCelsiusTem()
        {
            return celsiusTemp;
        }
        
        public double getElevation()
        {

           
            return airportElevation;
        }
    }
}
