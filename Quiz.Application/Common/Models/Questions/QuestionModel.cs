using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Common.Models.Questions
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public string Answer { get; set; }
    }
}
