using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GradingApp
{
    public partial class Form1 : Form
    {
        private string participation;
        private string projectOne;
        private string projectTwo;
        private string projectThree;
        private string midtermExam;
        private string finalExam;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.tfParticipation.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //assign text fields to empty string
            this.tfParticipation.Text = "";
            this.tfProjectOne.Text = "";
            this.tfProjectTwo.Text = "";
            this.tfProjectThree.Text = "";
            this.tfExam.Text = "";
            this.tfFinal.Text = "";

            this.tfParticipation.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.tfParticipation.Text) ||
                String.IsNullOrEmpty(this.tfProjectOne.Text) ||
                String.IsNullOrEmpty(this.tfProjectTwo.Text) ||
                String.IsNullOrEmpty(this.tfProjectThree.Text) ||
                String.IsNullOrEmpty(this.tfExam.Text) ||
                String.IsNullOrEmpty(this.tfFinal.Text))
            {
                MessageBox.Show("Text fields are empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tfParticipation.Focus();
            }
            else {

                participation = this.tfParticipation.Text;
                projectOne = this.tfProjectOne.Text;
                projectTwo = this.tfProjectTwo.Text;
                projectThree = this.tfProjectThree.Text;
                midtermExam = this.tfExam.Text;
                finalExam = this.tfFinal.Text;

                if (isValid(participation) && isValid(projectOne) && isValid(projectTwo) &&
                    isValid(projectThree) && isValid(midtermExam) && isValid(finalExam))
                {
                    double x1 = Convert.ToDouble(participation);
                    double x2 = Convert.ToDouble(projectOne);
                    double x3 = Convert.ToDouble(projectTwo);
                    double x4 = Convert.ToDouble(projectThree);
                    double x5 = Convert.ToDouble(midtermExam);
                    double x6 = Convert.ToDouble(finalExam);

                    double result = getResultNumber(x1, x2, x3, x4, x5, x6);

                    if (result > 100)
                    {
                        MessageBox.Show("Data is too big or invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.tfParticipation.Focus();
                    }
                    else {
                        string resultL = getResultLetter(result);

                        this.tfGrade.Text = result.ToString("f2"); //to digits after point
                        this.tfQulity.Text = resultL;
                    }  
                }
                else
                {
                    MessageBox.Show("Data is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.tfParticipation.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result;
            result = MessageBox.Show("Are you sure?", "Confiramtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //close form
                this.Close();
            }
            else {
                this.tfParticipation.Focus();    
            }
        }

        private double getResultNumber(double attend, double pOne, double pTwo, double pThree, double exam, double fExam) {

            double result = 0.0;

            result = (attend * 0.10) + (pOne * 0.15) + (pTwo * 0.15) + (pThree * 0.15) + (exam * 0.20) + (fExam * 0.25);

            return result;
        }

        private string getResultLetter(double data) {
            string result = "";

            if (data <= 100 && data >= 94)
            {
                result = "A";
            }
            else if (data < 94 && data >= 90)
            {
                result = "A-";
            }
            else if (data < 90 && data >= 87)
            {
                result = "B+";
            }
            else if (data < 87 && data >= 83)
            {
                result = "B";
            }
            else if (data < 83 && data >= 80)
            {
                result = "B-";
            }
            else if (data < 80 && data >= 77)
            {
                result = "C+";
            }
            else if (data < 77 && data >= 70)
            {
                result = "C";
            }
            else if (data < 70 && data >= 60)
            {
                result = "D";
            }
            else if (data < 60)
            {
                result = "F";
            }

            return result;
        }

        private bool isValid(string str) {
            return Regex.IsMatch(str, @"^[0-9]+$");
        }
    }
}
