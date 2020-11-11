using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost33259
    {
        private Dictionary<string, object> _fromReceiptAndDistribution;

        private string _selectedExecutionFlange;


        public double StandartGosts33259(Dictionary<string, object> fromReceiptAndDistribution)
        {
            _fromReceiptAndDistribution = fromReceiptAndDistribution;
            //Получение исполнений ГОСТов и тд. введенных пользователем
            _selectedExecutionFlange = _fromReceiptAndDistribution["SelectedExecutionFlange"].ToString();

            if (_selectedExecutionFlange == "Исполнение A" || _selectedExecutionFlange == "Исполнение B" || 
                _selectedExecutionFlange == "Исполнение J" || _selectedExecutionFlange == "Исполнение K")
            {
                double b = _fromReceiptAndDistribution["StandartPlugsChecked"] is true || 
                    _fromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"])
                    : Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) * 2;
                return b;
            }
            if (_selectedExecutionFlange == "Исполнение C и D" || _selectedExecutionFlange == "Исполнение E и F")
            {
                double b = _fromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                          _fromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(_fromReceiptAndDistribution["inResulth2"])
                    : Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(_fromReceiptAndDistribution["inResulth2"]));
                return b;
            }
            if (_selectedExecutionFlange == "Исполнение L и M")
            {
                double b = _fromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                          _fromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(_fromReceiptAndDistribution["inResulth5"])
                    : Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(_fromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(_fromReceiptAndDistribution["inResulth5"]));
                return b;
            }
            return 0;
        }
    }
}