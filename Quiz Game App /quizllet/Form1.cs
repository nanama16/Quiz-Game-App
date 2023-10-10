using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace quizllet
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;
        private bool quizCompleted;

        public Form1()
        {
            InitializeComponent();
            InitializeQuestions();
            currentQuestionIndex = 0;
            score = 0;
            quizCompleted = false;
            UpdateQuestionAndAnswers();
        }

        private void InitializeQuestions()
        {

            questions = new List<Question>
{
                new Question("Which country hosted the 2016 Summer Olympics?", new List<string> { "a) Brazil", "b) China", "c) USA" }, "a"),
                new Question("What is the chemical symbol for gold?", new List<string> { "a) Gd", "b) Ag", "c) Au" }, "c"),
                new Question("Who is known as the 'Father of Modern Physics'?", new List<string> { "a) Max Planck", "b) Niels Bohr", "c) Albert Einstein" }, "c"),
                new Question("What is the capital of Italy?", new List<string> { "a) Rome", "b) Milan", "c) Venice" }, "a"),
                new Question("Which planet is known as the 'Blue Planet'?", new List<string> { "a) Earth", "b) Neptune", "c) Uranus" }, "a"),
                new Question("Who wrote the famous play 'Hamlet'?", new List<string> { "a) William Shakespeare", "b) Oscar Wilde", "c) Tennessee Williams" }, "a"),
                new Question("What is the chemical symbol for carbon?", new List<string> { "a) C", "b) Co", "c) Ca" }, "a"),
                new Question("Which river is the longest in the world?", new List<string> { "a) Nile", "b) Amazon", "c) Mississippi" }, "a"),
                new Question("Which animal is known as the 'King of the Jungle'?", new List<string> { "a) Elephant", "b) Lion", "c) Tiger" }, "b"),
                new Question("What is the largest organ in the human body?", new List<string> { "a) Liver", "b) Brain", "c) Skin" }, "c")
};

        }

        private void UpdateQuestionAndAnswers()
        {
            if (currentQuestionIndex < questions.Count)
            {
                Question currentQuestion = questions[currentQuestionIndex];
                question.Text = currentQuestion.QuestionText;


                radioButton1.Text = currentQuestion.Answers[0];
                radioButton2.Text = currentQuestion.Answers[1];
                radioButton3.Text = currentQuestion.Answers[2];
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                


                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else
            {
                quizCompleted = true;
                question.Text = "Quiz complete!";
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                button3.Visible = true;
                button1.Visible = false;
                MessageBox.Show($"Your score: {score} out of {questions.Count}");
            }
        }

        private void CheckAnswer(string selectedAnswer)
        {
            if (currentQuestionIndex < questions.Count)
            {
                Question currentQuestion = questions[currentQuestionIndex];
                if (currentQuestion.CorrectAnswer == selectedAnswer)
                {
                    score++;
                }

                currentQuestionIndex++;
                UpdateQuestionAndAnswers();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton3.Checked = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private string GetSelectedAnswer()
        {
            if (radioButton1.Checked)
                return "a";
            if (radioButton2.Checked)
                return "b";
            if (radioButton3.Checked)
                return "c";

            return null;
        }

        private void ShowCorrectAnswers()
        {
            if (currentQuestionIndex < questions.Count)
            {   

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quizCompleted)
            {
                ShowCorrectAnswers();

            }
            else
            {
                string selectedAnswer = GetSelectedAnswer();
                if (selectedAnswer != null)
                {
                    CheckAnswer(selectedAnswer);
                }
                else
                {
                    MessageBox.Show("Please select an answer before proceeding to the next question.");
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (quizCompleted)
            {
                ShowCorrectAnswers();
                currentQuestionIndex = 0;
                Question currentQuestion = questions[currentQuestionIndex];
                question.Text = currentQuestion.QuestionText;

                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                button1.Enabled = true;
                radioButton1.Text = currentQuestion.Answers[0];
                radioButton1.Text = currentQuestion.Answers[0];
                radioButton2.Text = currentQuestion.Answers[1];
                radioButton3.Text = currentQuestion.Answers[2];
                button3.Visible = false;
                button4.Visible = true;
                button5.Visible = false;
               


                if (currentQuestionIndex >= 0 && currentQuestionIndex < questions.Count)
                {
                    if (currentQuestion.CorrectAnswer == "a")
                    {
                        radioButton1.ForeColor = Color.Green;
                        radioButton2.Enabled = false;
                        radioButton3.Enabled = false;

                    }
                    else if (currentQuestion.CorrectAnswer == "b")
                    {
                        radioButton2.ForeColor = Color.Green;
                        radioButton1.Enabled = false;
                        radioButton3.Enabled = false;

                    }
                    else if (currentQuestion.CorrectAnswer == "c")
                    {
                        radioButton3.ForeColor = Color.Green;
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = false;

                    }
                }

                 

            }
            else
            {
                
                
                quizCompleted = false;
                UpdateQuestionAndAnswers();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;

                // Display the next question
                DisplayQuestion(currentQuestionIndex);

                // Disable radio buttons after the user selects an answer
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
            else
            {
                quizCompleted = true;
                // Handle the case when all questions are answered
            }

            // Show the "Previous" button if we are on a question other than the first one
            button5.Visible = currentQuestionIndex >= 1;
        }

        private void DisplayQuestion(int questionIndex)
        {
            Question currentQuestion = questions[questionIndex];
            
            question.Text = currentQuestion.QuestionText;
            radioButton1.Text = currentQuestion.Answers[0];
            radioButton2.Text = currentQuestion.Answers[1];
            radioButton3.Text = currentQuestion.Answers[2];

            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;

            if (currentQuestion.CorrectAnswer == "a")
            {
                radioButton1.ForeColor = Color.Green;
            }
            else if (currentQuestion.CorrectAnswer == "b")
            {
                radioButton2.ForeColor = Color.Green;
            }
            else if (currentQuestion.CorrectAnswer == "c")
            {
                radioButton3.ForeColor = Color.Green;
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            

            if (questions.Count  > currentQuestionIndex && currentQuestionIndex > 0)
            {

                currentQuestionIndex = currentQuestionIndex - 1;
                Question currentQuestion = questions[currentQuestionIndex];
                
                question.Text = currentQuestion.QuestionText;
                radioButton1.Text = currentQuestion.Answers[0];
                radioButton2.Text = currentQuestion.Answers[1];
                radioButton3.Text = currentQuestion.Answers[2];

                if (currentQuestion.CorrectAnswer == "a")
                {
                    radioButton1.ForeColor = Color.Green;
                    radioButton2.ForeColor = Color.White;
                    radioButton3.ForeColor = Color.White;
                }
                else if (currentQuestion.CorrectAnswer == "b")
                {
                    radioButton2.ForeColor = Color.Green;
                    radioButton1.ForeColor = Color.White;
                    radioButton3.ForeColor = Color.White;
                }
                else if (currentQuestion.CorrectAnswer == "c")
                {
                    radioButton3.ForeColor = Color.Green;
                    radioButton2.ForeColor = Color.White;
                    radioButton1.ForeColor = Color.White;
                }

            }
            else { quizCompleted = true; }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }

}



public class Question
{
    public string QuestionText { get; private set; }
    public List<string> Answers { get; private set; }
    public string CorrectAnswer { get; private set; }

    public Question(string questionText, List<string> answers, string correctAnswer)
    {
        QuestionText = questionText;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }
}



