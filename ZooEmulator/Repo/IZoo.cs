using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Repo
{
    interface IZoo
    {
        void Create(string name, string type);
        void Feed(string name);
        void Delete(string name);
    }
}
