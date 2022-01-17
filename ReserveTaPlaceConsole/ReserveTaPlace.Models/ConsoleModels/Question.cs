using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveTaPlace.Models.ConsoleModels
{
    public class Question
    {
        public Question(string text, QuestionType questionType)
        {
            _text = text;
            _possibleChoices = 0;
            _possibleResponses = new List<string>();
            _questionType = questionType;
            _answers = new List<Answer>();
        }
        public Question(string text, uint possibleChoices, QuestionType questionType) : this(text, questionType)
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _possibleResponses = new List<string>();
            _questionType = questionType;
            _answers = new List<Answer>();
        }
        private QuestionType _questionType;
        public QuestionType QuestionType
        {
            get { return _questionType; }
            set { _questionType = value; }
        }

        private List<Answer> _answers;
        private int _id { get; set; }
        private string _text;
        private uint _possibleChoices;
        private List<string> _possibleResponses;
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        public List<string> PossibleResponses
        {
            get { return _possibleResponses; }
            set { _possibleResponses = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public uint PossibleChoices
        {
            get { return _possibleChoices; }
            set { _possibleChoices = value; }
        }
        public int Id { get { return _id; } }
    }
}
