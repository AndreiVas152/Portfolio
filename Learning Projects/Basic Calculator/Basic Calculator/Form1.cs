using System;
using System.Linq;
using System.Windows.Forms;

namespace Basic_Calculator
{
    /// <summary>
    /// A basic calculator
    /// </summary>
    public partial class Form1 : Form
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Clearing Methods

        /// <summary>
        /// Clears the user input text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            //Clears the text from the user input text box

            this.UserInputText.Text = String.Empty;

            FocusInputText();
        }

        /// <summary>
        /// Deletes the first character in front of the cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            //Delete the value after the selected position
            DeleteTextValue();

            FocusInputText();
        }

        #endregion

        #region Operator Methods

        /// <summary>
        /// Adds the divide character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();
        }

        /// <summary>
        /// Calculates the equation inside the user input text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();

            FocusInputText();
        }

        /// <summary>
        /// Adds the plus character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();
        }

        /// <summary>
        /// Adds the multiplication character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimesButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();
        }

        /// <summary>
        /// Adds the minus character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();
        }
        #endregion

        #region Number Methods

        /// <summary>
        /// Adds the 7 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 8 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 9 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 4 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 5 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 6 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 1 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 2 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 3 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();
        }

        /// <summary>
        /// Adds the 0 character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();
        }

        /// <summary>
        /// Adds the . character to the text at the currently selected position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            FocusInputText();
        }

        #endregion

        #region Private Helpers
        /// <summary>
        /// Focuses the user input text
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        /// <summary>
        /// Inserts the given text into the user input text box
        /// </summary>
        /// <param name="value"></param>
        private void InsertTextValue(string value)
        {
            //Remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            //Set new text
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, value);

            //Restore the selection start
            this.UserInputText.SelectionStart = selectionStart + value.Length;

            //Set selection lenght to 0
            this.UserInputText.SelectionLength = 0;
        }


        /// <summary>
        /// Deletes the character to the right of the user input text box
        /// </summary>
        private void DeleteTextValue()
        {
            //Delete the character to the right of the selection
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;

            //Remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            //Restore the selection start
            this.UserInputText.SelectionStart = selectionStart;

            //Set selection lenght to 0
            this.UserInputText.SelectionLength = 0;
        }

        /// <summary>
        /// Calculates a given equation and outputs the answer to the text box
        /// </summary>
        private void CalculateEquation()
        {
            this.CalculationResultText.Text = ParseOperation();
        }

        private string ParseOperation()
        {
            try
            {
                // Get the user's equation input
                var input = this.UserInputText.Text;

                // Remove all spaces
                input = input.Replace(" ", "");

                // Create a new top-level operation
                var operation = new Operation();
                var leftSide = true;

                //Loop through each character of the input string starting from the left
                for (int i = 0; i < input.Length; i++)
                {
                    //TODO: Handle order priority

                    //Check if the current character is a number, using .Any (linq method, checks every character in a string)
                    if ("0123456789.".Any(c => input[i] == c))
                    {
                        if (leftSide)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        else
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);
                    }
                    // If it is an operator ( + - * / ) set the operator type
                    else if ("+-*/".Any(c => input[i] == c))
                    {
                        // If we are on the right side already, we now need to calculate our current operation
                        // and set the result to the left side of the next operation
                        if (!leftSide)
                        {
                            var operatorType = GetOperationType(input[i]);

                            if (operation.RightSide.Length == 0)
                            {
                                // Check the operator is not a minus (could be a negative number)
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without a right side number");

                                // If reaching this point, operator type is a minus and there is currently no left number, add the minus to the number
                                operation.RightSide += input[i];
                            }
                            else
                            {
                                //Calculate previous equation and set to left side
                                operation.LeftSide = CalculateOperation(operation);

                                //Set new operator
                                operation.OperationType = operatorType;

                                // Clear the previous right number
                                operation.RightSide = String.Empty;
                            }


                        }
                        else
                        {
                            //Get the operator Type
                            var operatorType = GetOperationType(input[i]);

                            //Check if we actually have a left side number
                            if (operation.LeftSide.Length == 0)
                            {
                                // Check the operator is not a minus (could be a negative number)
                                if (operatorType != OperationType.Minus)
                                    throw new InvalidOperationException($"Operator (+ * / or more than one -) specified without a left side number");

                                // If reaching this point, operator type is a minus and there is currently no left number, add the minus to the number
                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                //If we get here, we have a left number and now an operator, so we want to move to the right side

                                //Set the operation type
                                operation.OperationType = operatorType;

                                leftSide = false;
                            }
                        }
                    }

                }

                // If we are done parsing, and there were no exceptions
                // Calculate the current operation
                return CalculateOperation(operation);
                return String.Empty;
            }
            catch (Exception ex)
            {
                return $"Invalid equation. {ex.Message}";
            }

        }

        /// <summary>
        /// Calculates an <see cref="Operation"/> and returns the result.
        /// </summary>
        /// <param name="operation">Operation to calculate</param>
        /// <exception cref="NotImplementedException"></exception>
        private string CalculateOperation(Operation operation)
        {
            //Store the number values of the string representations
            decimal left = 0;
            decimal right = 0;

            //Check if we have a valid left side number
            if (string.IsNullOrEmpty(operation.LeftSide) || !decimal.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException($"Left side of the operation was not a number {operation.LeftSide}");

            //Check if we have a valid left side number
            if (string.IsNullOrEmpty(operation.RightSide) || !decimal.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException($"Right side of the operation was not a number {operation.RightSide}");

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    default:
                        throw new InvalidOperationException($"Unknown operator type when calculating operation. { operation.OperationType}");

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to calculate operation {operation.LeftSide} {operation.OperationType} {operation.RightSide}. {ex.Message}");
            }

        }

        /// <summary>
        /// Accepts a character and returns the known <see cref="OperationType"/>
        /// </summary>
        /// <param name="character"> The character to parse</param>
        /// <exception cref="InvalidOperationException"></exception>
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Add;
                case '-':
                    return OperationType.Minus;
                case '/':
                    return OperationType.Divide;
                case '*':
                    return OperationType.Multiply;
                default:
                    throw new InvalidOperationException($"Unknown operator type { character }");
            }    
        }

        /// <summary>
        /// Attempts to add a new character to the current number, checking for valid characters as it goes
        /// </summary>
        /// <param name="currentNumber">The current number string</param>
        /// <param name="newCharacter">The new character to append to the string</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            //Check if therei s already a . in the number
            if (newCharacter == '.' && currentNumber.Contains('.'))
                throw new InvalidOperationException($"Number {currentNumber} already contains a . and another cannot be added");

            return currentNumber + newCharacter;
        }
        #endregion
    }
}
