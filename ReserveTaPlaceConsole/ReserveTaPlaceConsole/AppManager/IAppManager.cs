using ReserveTaPlace.Models.CModels;

namespace ReserveTaPlace.AppManager
{
    internal interface IAppManager
    {
        Answer ReadUserEntry(Question question);
        void WriteQuestion(Question question);
    }
}
