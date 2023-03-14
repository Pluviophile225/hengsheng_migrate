using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class function
    {
        public string name { get; set; }
        public string returnValue { get; set; }
        public int length { get; set; }

        public string[] param = new string[20];

        public static bool operator ==(function p1, function p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            if(p1.name != p2.name)
            {
                return false;
            }
            if(p1.returnValue != p2.returnValue) { return false; }

            if (p1.length != p2.length) return false;

            for(int i = 0; i < p1.length; i++)
            {
                if (p1.param[i] != p2.param[i]) return false;
            }
            return true;
        }

        public static bool operator !=(function p1, function p2)
        {
            return !(p1 == p2);
        }
    }
}

class functionComparer : IEqualityComparer<function>
{
    public bool Equals(function p1, function p2)
    {
        if (ReferenceEquals(p1, p2))
        {
            return true;
        }

        if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
        {
            return false;
        }

        if (p1.name != p2.name)
        {
            return false;
        }
        if (p1.returnValue != p2.returnValue) { return false; }

        if (p1.length != p2.length) return false;

        for (int i = 0; i < p1.length; i++)
        {
            if (p1.param[i] != p2.param[i]) return false;
        }
        return true;
    }

    public int GetHashCode( function obj)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + obj.name.GetHashCode();
            hash = hash * 23 + obj.returnValue.GetHashCode();
            hash = hash * 23 + obj.length.GetHashCode();
            hash = hash * 23 + obj.param.GetHashCode();
            return hash;
        }
    }

    
}
