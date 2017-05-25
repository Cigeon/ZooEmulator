using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator
{
    class Message
    {
        private static readonly Message instance = new Message();

        public string Body { get; set; }

        private Message()
        {
            Body = "";
        }

        public static Message GetInstance()
        {
            return instance;
        }
    }
}
