using ReserveTaPlace.Models.ConsoleModels;

namespace ReserveTaPlace.AppManager
{
    internal interface IAppManager
    {
        Answer ReadUserEntry(Question question);
        void WriteQuestion(Question question);
    }
}
