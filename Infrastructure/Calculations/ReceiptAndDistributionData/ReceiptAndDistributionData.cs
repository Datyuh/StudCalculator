using System;
using System.Collections.Generic;
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
        private string SelectedTheard; //Выборка диаметра шпилек по ГОСТу

        private string SelectedExecutionFlange;

        private double ExrcuteAtk2618593B; //Выборка толщины заглушек поворотных из ГОСТа
        private double ExrcuteAtk2618593BNonStandart; //Выборка толщины заглушек поворотных пользователем
        private double ExecuteAtk242000290B; //Выборка толщины заглушек или крышек из ГОСТа
        private double ExecuteAtk242000290BNonStandart; //Выборка толщины заглушек или крышек пользователем

        private double ExecuteStandartWashers; //Выборка толщины стандартных шайб
        private double ExecuteNonStandartWashers; //Выборка толщины не стандартных шайб введенных пользователем

        private double ExecuteNonStandartGasket; //Выборка нестандартной толщины прокладки пользователем
        private double ExecuteOvalGasket; //Выборка стандартных овальных прокладок
        private double ExecuteOctagonalGasket; //Выборка стандартных восьмигранных прокладок

        private bool StandartPlugsChecked;
        private bool NonStandartPlugsChecked;

        private string ResultSumFlange;

        private double InResultPNuts(string getPNuts) => new DbNutsOst26_2041_96().ExtractThicknessPLarge(getPNuts); //Выборка из ОСТа шага резьбы гаек
        private double InResultHNuts(string getHNuts) => new DbNutsOst26_2041_96().ExtractThicknessHLarge(getHNuts); //Выборка из ОСТа высоты гаек
        private double ResultInMainWindow => ResultOutBaseAllGosts();
        //Получение из базы кол-во отверстий под шпильки
        private double InResultnSumStud(string selectedPn, string selectedDn) => new DbWorkGost33259().ExecutionThicknessFlangen_type1(selectedPn, selectedDn);

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

            #region Если используются заглушки поворотные

            if (ReceiptAndDistributionOfDataCheckBox["StandartRotaryPlugsChecked"] is true)
            {
                ExrcuteAtk2618593B = new DbRotarPylugATK_26_18_5_93().Executeb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartRotaryPlugFromComboBox"].ToString());
                ExrcuteAtk2618593BNonStandart = 0;
            }

            else if (ReceiptAndDistributionOfDataCheckBox["NonStandartRotaryPlugsChecked"] is true)
            {
                ExrcuteAtk2618593BNonStandart = Convert.ToDouble(ReceiptAndDistributionOfDatas["NonStandartRotaryPlugsTextRead"]);
                ExrcuteAtk2618593B = 0;
            }

            else
            {
                ExrcuteAtk2618593B = 0;
                ExrcuteAtk2618593BNonStandart = 0;
            }

            #endregion

            #region Если используются заглушки или крышки

            if (StandartPlugsChecked is true)
            {
                ExecuteAtk242000290B = new DbCapsATK24_200_02_90().Executedb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartPlugsFromComboBox"].ToString());
                ExecuteAtk242000290BNonStandart = 0;


            }
            else if (NonStandartPlugsChecked is true)
            {
                ExecuteAtk242000290BNonStandart =
                    Convert.ToDouble(ReceiptAndDistributionOfDatas["NonStandartPlugsTextRead"]);
                ExecuteAtk242000290B = 0;
            }
            else
            {
                ExecuteAtk242000290B = 0;
                ExecuteAtk242000290BNonStandart = 0;
            }

            #endregion

            #region Если используются шайбы

            if (ReceiptAndDistributionOfDataCheckBox["StandartThicknessWasherCheckboxChecked"] is true)
            {
                ExecuteStandartWashers = new DbStandartWashersOST26204296().StandartWashers(SelectedTheard);
                ExecuteNonStandartWashers = 0;
            }
            else if(ReceiptAndDistributionOfDataCheckBox["NonStandartThicknessWasherCheckboxChecked"] is true)
            {
                ExecuteNonStandartWashers = Convert.ToDouble(ReceiptAndDistributionOfDatas["ThicknessWasherTextRead"]);
                ExecuteStandartWashers = 0;
            }
            else
            {
                ExecuteStandartWashers = 0;
                ExecuteNonStandartWashers = 0;
            }

            #endregion

            #region Использование прокладок в зависимости от выбранных пользователем

            if (ReceiptAndDistributionOfDataCheckBox["StandartOvalGasketsCheckboxChecked"] is true)
            {
                ExecuteOvalGasket = new DbOvalGasket().ExecutedOvalGasket(SelectedPn, SelectedDn);
                ExecuteNonStandartGasket = 0;
                ExecuteOctagonalGasket = 0;
            }
            else if (ReceiptAndDistributionOfDataCheckBox["StandartOctahedralGasketsCheckboxChecked"] is true)
            {
                ExecuteOctagonalGasket = new DbOctagonalGasket().ExecutedOctogonalGasket(SelectedPn, SelectedDn);
                ExecuteNonStandartGasket = 0;
                ExecuteOvalGasket = 0;
            }
            else
            {
                ExecuteNonStandartGasket = Convert.ToDouble(ReceiptAndDistributionOfDatas["ThicknessGasketTextRead"]);
                ExecuteOvalGasket = 0;
                ExecuteOctagonalGasket = 0;
            }

            #endregion

        }

        #region Передача для расчета данных со всех ГОСТов и не стандартных фланцев

        public string ResultAllGostAndNonGost()
        {
            //Формула расчета кол-ва шпилек
            ResultSumFlange = (InResultnSumStud(SelectedPn, SelectedDn) * Convert.ToDouble(ReceiptAndDistributionOfDatas["SumFlangeTextRead"])).ToString();

            var resultToResultInViewModels = new Dictionary<string, object>
            {
                {"B", ResultInMainWindow},
                {"MaterialStudFromCombobox", ReceiptAndDistributionOfDatas["MaterialStudFromCombobox"]},
                {"ExecutionStudFromCombobox", ReceiptAndDistributionOfDatas["ExecutionStudFromCombobox"]},
                {"SelectedTheard", SelectedTheard},
                {"ExrcuteAtk2618593b", ExrcuteAtk2618593B},
                {"ExrcuteAtk2618593bNonStandart", ExrcuteAtk2618593BNonStandart},
                {"ExecuteAtk242000290b", ExecuteAtk242000290B},
                {"ExecuteAtk242000290bNonStandart", ExecuteAtk242000290BNonStandart},
                {"ExecuteNonStandartWashers", ExecuteNonStandartWashers},
                {"ExecuteStandartWashers", ExecuteStandartWashers},
                {"ExecuteOvalGasket", ExecuteOvalGasket},
                {"ExecuteOctagonalGasket", ExecuteOctagonalGasket},
                {"ExecuteNonStandartGasket", ExecuteNonStandartGasket},
                {"inResultPNuts", InResultPNuts(SelectedTheard)},
                {"inResultHNuts", InResultHNuts(SelectedTheard)},
            };
            string resultInMainWindow = new ResultInViewModel.ResultInViewModel().ReturnFromLotsman(resultToResultInViewModels);
            string resultInMainWindowPlusSumFlange = $"{resultInMainWindow} - кол-во шпилек {ResultSumFlange}шт.";

            return resultInMainWindow == "Вывод результатов..." ? "Вывод результатов..." : resultInMainWindowPlusSumFlange;
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
                SelectedTheard = new DbWorkGost33259().ExecutionThicknessFlangeTheard1(SelectedPn, SelectedDn);

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