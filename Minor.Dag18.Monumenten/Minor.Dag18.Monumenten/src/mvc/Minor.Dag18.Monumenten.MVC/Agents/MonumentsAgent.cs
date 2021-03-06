﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag18.Monumenten.MVC.Models;

namespace Minor.Dag18.Monumenten.MVC.Agents
{
    public class MonumentsAgent
        : IMonumentsAgent, IDisposable
    {
        public MonumentsAgent()
        {
            Monuments = new List<Monument>();
        }

        private IList<Monument> _monuments;
        public IList<Monument> Monuments {
            get
            {
                return _monuments;
            }
            private set
            {
                _monuments = value;
            }
        }
        
        public void AddMonument(Monument monument)
        {
            Monuments.Add(monument);
        }        

        public void Remove(string name)
        {
            _monuments.Remove(_monuments.Where(a => a.Name == name)
                .First());                        
        }

        public void Dispose()
        {

        }
    }
}
