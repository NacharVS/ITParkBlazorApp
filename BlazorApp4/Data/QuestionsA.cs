using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class QuestionsA
    {
        public QuestionsA(string question, List<TestAnswers> myProperty)
        {
            Question = question;
            MyProperty = myProperty;
        }

        public string Question { get; set; }
        public List<TestAnswers> MyProperty { get; set; }

        public static List<QuestionsA> GenerateQuestions()
        {
            List<QuestionsA> listToReturn = new List<QuestionsA>();
            List<TestAnswers> anwers = new List<TestAnswers>();
            anwers.Add(new TestAnswers("5", false));
            anwers.Add(new TestAnswers("2", false));
            anwers.Add(new TestAnswers("1", false)); 
            anwers.Add(new TestAnswers("4", true));
            listToReturn.Add(new QuestionsA("2+2 = ", anwers));
            return listToReturn;
        }
    }
}
