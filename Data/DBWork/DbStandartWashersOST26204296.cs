﻿using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbStandartWashersOST26204296
    {
        ApplicationContext db = new ApplicationContext();

        public double StandartWashers(string tread)
        {
            var executeStandartWashers = Convert.ToDouble(db.OST26_2042_96.Where(p => p.Thread == tread).Select(p => p.S).AsParallel());
            return executeStandartWashers;
        }
    }
}