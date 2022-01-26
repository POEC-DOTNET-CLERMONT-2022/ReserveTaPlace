namespace ReserveTaPlace.Models.CModels
{
    public class Answer
    {
        public Answer(string text, uint? choice, Question question)
        {
            _text = text;
            _choice = choice ?? 0;
            _question = question;
        }
        private int _id { get; set; }
        private string _text;
        private uint _choice;
        private Question _question;
        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }
        public uint Choice
        {
            get { return _choice; }
            set { _choice = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public int Id { get { return _id; } }
    }
}
