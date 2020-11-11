using System;
using System.Collections.Generic;
using System.Globalization;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData
{
    internal class ReceiptAndDistributionData
    {
        //Получение всех переменных который ввел пользователь
        private Dictionary<string, object> _receiptAndDistributionOfDatas;
        //Получение всех данных о дополнительных условиях для расчета
        private Dictionary<string, bool> _receiptAndDistributionOfDataCheckBox;

        #region Объявление переменных которые используются во всех гостах

        private string _selectedPn; //Выборка давления пользователем
        private string _selectedDn; //Выборка диаметра фланцев пользователем
        private string _selectedTheard; //Выборка диаметра шпилек по ГОСТу

        private string _selectedExecutionFlange;

        private bool _standartPlugsChecked;
        private bool _nonStandartPlugsChecked;

        private string _resultSumFlange;

        private double InResultPNuts(string getPNuts) => new DbNutsOst26_2041_96().ExtractThicknessPLarge(getPNuts); //Выборка из ОСТа шага резьбы гаек
        private double InResultHNuts(string getHNuts) => new DbNutsOst26_2041_96().ExtractThicknessHLarge(getHNuts); //Выборка из ОСТа высоты гаек
        private double ResultInMainWindow => ResultOutBaseAllGosts();
        //Получение из базы кол-во отверстий под шпильки
        private double InResultnSumStud(string selectedPn, string selectedDn) => new DbWorkGost33259().ExecutionThicknessFlangen_type1(selectedPn, selectedDn);
        //Выборка толщины заглушек в зависимости от условий
        private double[] ExrcuteAtkStandartOrNot2618593B => StandartOrNotRotaryPlugsChecked();
        //Выборка заглушек и крышек в зависимости от условий
        private double[] ExecuteAtkStandartOrNot242000290B => StandartOrNotPlugsChecked();
        //Выборка шайб в зависимости от условий
        private double[] ExecutedStandartOrNotWashers => ExecuteStandartOrNotWashers();
        //Выборка прокладок в зависимости от условий
        private double[] ExecutedOvalAndOctagonalOrNonStandartGasket => ExecuteOvalAndOctagonalOrNonStandartGasket();

        #endregion


        public ReceiptAndDistributionData(Dictionary<string, object> data, Dictionary<string, bool> dataCheckBox)
        {
            _receiptAndDistributionOfDatas = data;
            _receiptAndDistributionOfDataCheckBox = dataCheckBox;

            #region Получения значений для всех ГОСТов

            //Получения значения PN
            _selectedPn = _receiptAndDistributionOfDatas["PnSelectedFromComboBox"].ToString();
            //Получение значения DN
            _selectedDn = _receiptAndDistributionOfDatas["DnSelectedFromComboBox"].ToString();
            //Получение исполнений ГОСТов и тд. введенных пользователем
            _selectedExecutionFlange = _receiptAndDistributionOfDatas["ExecutionFromComboBox"].ToString();

            _standartPlugsChecked = _receiptAndDistributionOfDataCheckBox["StandartPlugsChecked"];
            _nonStandartPlugsChecked = _receiptAndDistributionOfDataCheckBox["NonStandartPlugsChecked"];

            #endregion
        }

        #region Передача для расчета данных со всех ГОСТов и не стандартных фланцев

        public string ResultAllGostAndNonGost()
        {
            //Формула расчета кол-ва шпилек
            _resultSumFlange =
                Convert.ToString(
                    InResultnSumStud(_selectedPn, _selectedDn) *
                    Convert.ToDouble(_receiptAndDistributionOfDatas["SumFlangeTextRead"]), CultureInfo.InvariantCulture);

            var resultToResultInViewModels = new Dictionary<string, object>
            {
                {"B", ResultInMainWindow},
                {"MaterialStudFromCombobox", _receiptAndDistributionOfDatas["MaterialStudFromCombobox"]},
                {"ExecutionStudFromCombobox", _receiptAndDistributionOfDatas["ExecutionStudFromCombobox"]},
                {"SelectedTheard", _selectedTheard},
                {"ExrcuteAtk2618593b", ExrcuteAtkStandartOrNot2618593B[0]},
                {"ExrcuteAtk2618593bNonStandart", ExrcuteAtkStandartOrNot2618593B[1]},
                {"ExecuteAtk242000290b", ExecuteAtkStandartOrNot242000290B[0]},
                {"ExecuteAtk242000290bNonStandart", ExecuteAtkStandartOrNot242000290B[1]},
                {"ExecuteStandartWashers", ExecutedStandartOrNotWashers[0]},
                {"ExecuteNonStandartWashers", ExecutedStandartOrNotWashers[1]},
                {"ExecuteOvalGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[0]},
                {"ExecuteOctagonalGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[1]},
                {"ExecuteNonStandartGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[2]},
                {"inResultPNuts", InResultPNuts(_selectedTheard)},
                {"inResultHNuts", InResultHNuts(_selectedTheard)},
            };
            string resultInMainWindow = new ResultInViewModel.ResultInViewModel().ReturnFromLotsman(resultToResultInViewModels);
            string resultInMainWindowPlusSumFlange = $"{resultInMainWindow} - кол-во шпилек {_resultSumFlange}шт.";

            return resultInMainWindow == "Вывод результатов..." ? "Вывод результатов..." : resultInMainWindowPlusSumFlange;
        }

        #endregion

        #region Если используются заглушки поворотные

        private double[] StandartOrNotRotaryPlugsChecked()
        {
            if (_receiptAndDistributionOfDataCheckBox["StandartRotaryPlugsChecked"] is true)
            {
                double exrcuteAtk2618593B = new DbRotarPylugATK_26_18_5_93().Executeb(_selectedPn, _selectedDn,
                    _receiptAndDistributionOfDatas["StandartRotaryPlugFromComboBox"].ToString());
                double exrcuteAtk2618593BNonStandart = 0;
                return new[] {exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart};
            }

            if (_receiptAndDistributionOfDataCheckBox["NonStandartRotaryPlugsChecked"] is true)
            {
                double exrcuteAtk2618593BNonStandart = Convert.ToDouble(_receiptAndDistributionOfDatas["NonStandartRotaryPlugsTextRead"]);
                double exrcuteAtk2618593B = 0;
                return new[] {exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart };
            }

            else
            {
                double exrcuteAtk2618593B = 0;
                double exrcuteAtk2618593BNonStandart = 0;
                return new[] {exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart };
            }
        }

        #endregion

        #region Если используются заглушки или крышки

        private double[] StandartOrNotPlugsChecked()
        {
            if (_standartPlugsChecked is true)
            {
                double executeAtk242000290B = new DbCapsAtk242000290().Executedb(_selectedPn, _selectedDn,
                    _receiptAndDistributionOfDatas["StandartPlugsFromComboBox"].ToString());
                double executeAtk242000290BNonStandart = 0;

                return new[] {executeAtk242000290B, executeAtk242000290BNonStandart};
            }
            if (_nonStandartPlugsChecked is true)
            {
                double executeAtk242000290BNonStandart =
                    Convert.ToDouble(_receiptAndDistributionOfDatas["NonStandartPlugsTextRead"]);
                double executeAtk242000290B = 0;
                return new[] { executeAtk242000290B, executeAtk242000290BNonStandart };
            }
            else
            {
                double executeAtk242000290B = 0;
                double executeAtk242000290BNonStandart = 0;
                return new[] { executeAtk242000290B, executeAtk242000290BNonStandart };
            }
        }

        #endregion

        #region Если используются шайбы

        private double[] ExecuteStandartOrNotWashers()
        {
            if (_receiptAndDistributionOfDataCheckBox["StandartThicknessWasherCheckboxChecked"] is true)
            {
                double executeStandartWashers = new DbStandartWashersOST26204296().StandartWashers(_selectedTheard);
                double executeNonStandartWashers = 0;
                return new[] {executeStandartWashers, executeNonStandartWashers};
            }
            if (_receiptAndDistributionOfDataCheckBox["NonStandartThicknessWasherCheckboxChecked"] is true)
            {
                double executeNonStandartWashers = Convert.ToDouble(_receiptAndDistributionOfDatas["ThicknessWasherTextRead"]);
                double executeStandartWashers = 0;
                return new[] { executeStandartWashers, executeNonStandartWashers };
            }
            else
            {
                double executeStandartWashers = 0;
                double executeNonStandartWashers = 0;
                return new[] { executeStandartWashers, executeNonStandartWashers };
            }
        }

        #endregion

        #region Использование прокладок в зависимости от выбранных пользователем

        private double[] ExecuteOvalAndOctagonalOrNonStandartGasket()
        {
            if (_receiptAndDistributionOfDataCheckBox["StandartOvalGasketsCheckboxChecked"] is true)
            {
                double executeOvalGasket = new DbOvalGasket().ExecutedOvalGasket(_selectedPn, _selectedDn);
                double executeNonStandartGasket = 0;
                double executeOctagonalGasket = 0;
                return new[] {executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket};
            }
            if (_receiptAndDistributionOfDataCheckBox["StandartOctahedralGasketsCheckboxChecked"] is true)
            {
                double executeOctagonalGasket = new DbOctagonalGasket().ExecutedOctogonalGasket(_selectedPn, _selectedDn);
                double executeNonStandartGasket = 0;
                double executeOvalGasket = 0;
                return new[] { executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket };
            }
            else
            {
                double executeNonStandartGasket = Convert.ToDouble(_receiptAndDistributionOfDatas["ThicknessGasketTextRead"]);
                double executeOvalGasket = 0;
                double executeOctagonalGasket = 0;
                return new[] { executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket };
            }
        }

        #endregion

        #region Расчет толщины фланцев в зависимости от выбраного пользователем

        public double ResultOutBaseAllGosts()
        {
            #region Сбор данных для расчета по ГОСТ 33259

            if (_receiptAndDistributionOfDatas["SelectionGostFromCombobox"].ToString() == "ГОСТ 33259-2015 Ряд 1")
            {
                var inResultb1 = new DbWorkGost33259().ExecutionThicknessFlangeb1(_selectedPn, _selectedDn); //Получение из базы толщины тарелки Тип 11
                var inResulth1 = new DbExecutionGost33259().ExecutionGost33259DF(_selectedPn, _selectedDn);
                var inResulth2 = new DbExecutionGost33259().ExecutionGost33259CE(_selectedPn, _selectedDn);
                var inResulth4 = new DbExecutionGost33259().ExecutionGost33259L(_selectedPn, _selectedDn);
                var inResulth5 = new DbExecutionGost33259().ExecutionGost33259M(_selectedPn, _selectedDn);
                //Выборка размера гайки для фланцев
                _selectedTheard = new DbWorkGost33259().ExecutionThicknessFlangeTheard1(_selectedPn, _selectedDn);

                var fromReceiptAndDistribution = new Dictionary<string, object>
                {
                    {"inResultb1", inResultb1},
                    {"inResulth1", inResulth1}, {"inResulth2", inResulth2},
                    {"inResulth4", inResulth4}, {"inResulth5", inResulth5},
                    {"StandartPlugsChecked", _standartPlugsChecked}, 
                    {"NonStandartPlugsChecked", _nonStandartPlugsChecked},
                    {"SelectedExecutionFlange", _selectedExecutionFlange},

                };

                double resultInMainWindow = new StandartGost33259().StandartGosts33259(fromReceiptAndDistribution);

                return resultInMainWindow;
            }
            return 0;

            #endregion
        }

        #endregion


    }
}