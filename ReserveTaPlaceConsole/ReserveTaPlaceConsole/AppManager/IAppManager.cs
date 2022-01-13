using ReserveTaPlace.Models.ConsoleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.AppManager
{
    internal interface IAppManager
    {
        Answer ReadUserEntry(Question question);
        void WriteQuestion(Question question);
    }
}
