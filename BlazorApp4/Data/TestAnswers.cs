using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class TestAnswers
    {
        public TestAnswers(string possibleAnswer, bool isRight)
        {
            PossibleAnswer = possibleAnswer;
            IsRight = isRight;
        }

        public string PossibleAnswer { get; set; }
        public bool IsRight { get; set; }
    }
}
