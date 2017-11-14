﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesmenEntities.Interface;
using System.Collections.ObjectModel;

namespace SalesmenEntities.Model
{
    public class Store : IStore
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IList<ISalesman> Salesmen { get; private set; }

        public Store(string name, IList<ISalesman> salesmen, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Salesmen = new List<ISalesman>(salesmen);
        }
    }
}
