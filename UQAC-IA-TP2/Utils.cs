using System;
using System.Collections.Generic;
using System.Linq;
using UQAC_IA_TP2.core;

namespace UQAC_IA_TP2
{
    public static class Utils<T>
    {
        public static List<Variable<T>> SubArrayFirstSameElements(List<Variable<T>> list)
        {
            int maxIndex = 0;
            int countFirst = list.First().Domain.Count;
            foreach (var v in list)
            {
                if (v.Domain.Count != countFirst)
                    break;
                maxIndex++;
            }
            return list.GetRange(0, maxIndex);
        } 
    }

    public class Position : IComparable
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(object? obj)
        {
            if (obj is Position pos2)
            {
                return Y > pos2.Y ? 1 : (Y < pos2.Y ? -1 : (X >= pos2.X ? 1 : -1));
            }
            return -1;
        }
    }
}