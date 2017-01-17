using Minor.Dag18.Monumenten.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag18.Monumenten.MVC.Agents
{
    public interface IMonumentsAgent 
        : IDisposable
    {
        IList<Monument> Monuments { get; }

        void AddMonument(Monument monument);
        void Remove(string name);
    }
}
