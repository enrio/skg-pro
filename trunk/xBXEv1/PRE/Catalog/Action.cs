﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRE.Catalog
{
    using DAL.Entities;
    using System.Collections;

    public class Action : CollectionBase
    {
        public Pol_User Pol_User { set; get; }

        public string this[int index]
        {
            get { return (string)List[index]; }
            set { List[index] = value; }
        }

        public int Add(string value)
        {
            return List.Add(value);
        }

        public bool Contains(string value)
        {
            return List.Contains(value);
        }

        public void CopyTo(string[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int IndexOf(string value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, string value)
        {
            List.Insert(index, value);
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }
    }
}