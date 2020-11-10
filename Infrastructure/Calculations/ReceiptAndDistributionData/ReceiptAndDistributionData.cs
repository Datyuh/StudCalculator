using System;
using System.Collections.Generic;
using System.Globalization;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData
{
    internal class ReceiptAndDistributionData
    {
        //Получение всех переменных который ввел пользователь
        private Dictionary<string, object> ReceiptAndDistributionOfDatas;
        //Получение всех данных о дополнительных условиях для расчета
        private Dictionary<string, bool> ReceiptAndDistributionOfDataCheckBox;

        #region Объявление переменных которые используются во всех гостах

        private string SelectedPn; //Выборка давления пользователем
        private string SelectedDn; //Выборка диаметра фланцев пользователем
        private string _selectedTheard; //Выборка диаметра шпилек по ГОСТу

        private string SelectedExecutionFlange;

        private bool StandartPlugsChecked;
        private bool NonStandartPlugsChecked;

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
            ReceiptAndDistributionOfDatas = data;
            ReceiptAndDistributionOfDataCheckBox = dataCheckBox;

            #region Получения значений для всех ГОСТов

            //Получения значения PN
            SelectedPn = ReceiptAndDistributionOfDatas["PnSelectedFromComboBox"].ToString();
            //Получение значения DN
            SelectedDn = ReceiptAndDistributionOfDatas["DnSelectedFromComboBox"].ToString();
            //Получение исполнений ГОСТов и тд. введенных пользователем
            SelectedExecutionFlange = ReceiptAndDistributionOfDatas["ExecutionFromComboBox"].ToString();

            StandartPlugsChecked = ReceiptAndDistributionOfDataCheckBox["StandartPlugsChecked"];
            NonStandartPlugsChecked = ReceiptAndDistributionOfDataCheckBox["NonStandartPlugsChecked"];

            #endregion
        }

        #region Передача для расчета данных со всех ГОСТов и не стандартных фланцев

        public string ResultAllGostAndNonGost()
        {
            //Формула расчета кол-ва шпилек
            _resultSumFlange =
                Convert.ToString(
                    InResultnSumStud(SelectedPn, SelectedDn) *
                    Convert.ToDouble(ReceiptAndDistributionOfDatas["SumFlangeTextRead"]), CultureInfo.InvariantCulture);

            var resultToResultInViewModels = new Dictionary<string, object>
            {
                {"B", ResultInMainWindow},
                {"MaterialStudFromCombobox", ReceiptAndDistributionOfDatas["MaterialStudFromCombobox"]},
                {"ExecutionStudFromCombobox", ReceiptAndDistributionOfDatas["ExecutionStudFromCombobox"]},
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
            if (ReceiptAndDistributionOfDataCheckBox["StandartRotaryPlugsChecked"] is true)
            {
                double exrcuteAtk2618593B = new DbRotarPylugATK_26_18_5_93().Executeb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartRotaryPlugFromComboBox"].ToString());
                double exrcuteAtk2618593BNonStandart = 0;
                return new[] {exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart};
            }

            if (ReceiptAndDistributionOfDataCheckBox["NonStandartRotaryPlugsChecked"] is true)
            {
                double exrcuteAtk2618593BNonStandart = Convert.ToDouble(ReceiptAndDistributionOfDatas["NonStandartRotaryPlugsTextRead"]);
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
            if (StandartPlugsChecked is true)
            {
                double executeAtk242000290B = new DbCapsATK24_200_02_90().Executedb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartPlugsFromComboBox"].ToString());
                double executeAtk242000290BNonStandart = 0;

                return new[] {executeAtk242000290B, executeAtk242000290BNonStandart};
            }
            if (NonStandartPlugsChecked is true)
            {
                double executeAtk242000290BNonStandart =
                    Convert.ToDouble(ReceiptAndDistributionOfDatas["NonStandartPlugsTextRead"]);
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
            if (ReceiptAndDistributionOfDataCheckBox["StandartThicknessWasherCheckboxChecked"] is true)
            {
                double executeStandartWashers = new DbStandartWashersOST26204296().StandartWashers(_selectedTheard);
                double executeNonStandartWashers = 0;
                return new[] {executeStandartWashers, executeNonStandartWashers};
            }
            if (ReceiptAndDistributionOfDataCheckBox["NonStandartThicknessWasherCheckboxChecked"] is true)
            {
                double executeNonStandartWashers = Convert.ToDouble(ReceiptAndDistributionOfDatas["ThicknessWasherTextRead"]);
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
            if (ReceiptAndDistributionOfDataCheckBox["StandartOvalGasketsCheckboxChecked"] is true)
            {
                double executeOvalGasket = new DbOvalGasket().ExecutedOvalGasket(SelectedPn, SelectedDn);
                double executeNonStandartGasket = 0;
                double executeOctagonalGasket = 0;
                return new[] {executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket};
            }
            if (ReceiptAndDistributionOfDataCheckBox["StandartOctahedralGasketsCheckboxChecked"] is true)
            {
                double executeOctagonalGasket = new DbOctagonalGasket().ExecutedOctogonalGasket(SelectedPn, SelectedDn);
                double executeNonStandartGasket = 0;
                double executeOvalGasket = 0;
                return new[] { executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket };
            }
            else
            {
                double executeNonStandartGasket = Convert.ToDouble(ReceiptAndDistributionOfDatas["ThicknessGasketTextRead"]);
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

            if (ReceiptAndDistributionOfDatas["SelectionGostFromCombobox"].ToString() == "ГОСТ 33259-2015 Ряд 1")
            {
                var inResultb1 = new DbWorkGost33259().ExecutionThicknessFlangeb1(SelectedPn, SelectedDn); //Получение из базы толщины тарелки Тип 11
                var inResulth1 = new DbExecutionGost33259().ExecutionGost33259DF(SelectedPn, SelectedDn);
                var inResulth2 = new DbExecutionGost33259().ExecutionGost33259CE(SelectedPn, SelectedDn);
                var inResulth4 = new DbExecutionGost33259().ExecutionGost33259L(SelectedPn, SelectedDn);
                var inResulth5 = new DbExecutionGost33259().ExecutionGost33259M(SelectedPn, SelectedDn);
                //Выборка размера гайки для фланцев
                _selectedTheard = new DbWorkGost33259().ExecutionThicknessFlangeTheard1(SelectedPn, SelectedDn);

                var fromReceiptAndDistribution = new Dictionary<string, object>
                {
                    {"inResultb1", inResultb1},
                    {"inResulth1", inResulth1}, {"inResulth2", inResulth2},
                    {"inResulth4", inResulth4}, {"inResulth5", inResulth5},
                    {"StandartPlugsChecked", StandartPlugsChecked}, 
                    {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                    {"SelectedExecutionFlange", SelectedExecutionFlange},

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