using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbStandartWashersOST26204296
    {
        readonly DbModelFromVnmData db = new DbModelFromVnmData();

        public double StandartWashers(string tread)
        {
            var executeStandartWashers = Convert.ToDouble(db.OGK_StudCalculator_OST26_2042_96.Where(p => p.Thread == tread).Select(p => p.S).First());
            return executeStandartWashers;
        }
    }
}