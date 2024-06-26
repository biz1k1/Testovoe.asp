using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Service
{
    public static class Check
    {
        public static bool CheckWord(string word)
        {
            if (word == "Да" || word=="да")
            {
                return true ;
            }
            if (word == null)
            {
                throw new Exception(message:"Пустое значение");
            }
            return false;
        }
    }
}
