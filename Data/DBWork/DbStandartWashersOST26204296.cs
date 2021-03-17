using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbStandartWashersOst26204296
    {
        readonly DbModelFromVnmData.DbModelFromVnmData db = new();

        public double StandartWashers(string tread)
        {
            var executeStandartWashers = Convert.ToDouble(db.OGK_StudCalculator_OST26_2042_96.Where(p => p.Thread == tread).Select(p => p.S).First());
            return executeStandartWashers;
        }
    }
}