using System;
using System.Collections.Generic;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData
{
    internal class ReceiptAndDistributionData
    {
        //Получение всех переменных который ввел пользователь
        public Dictionary<string, object> ReceiptAndDistributionOfDatas;
        //Получение всех данных о дополнительных условиях для расчета
        public Dictionary<string, bool> ReceiptAndDistributionOfDataCheckBox;

        #region Объявление переменных которые используются во всех гостах

        public string SelectedPn; //Выборка давления пользователем
        public string SelectedDn; //Выборка диаметра фланцев пользователем
        public string SelectedTheard; //Выборка диаметра шпилек по ГОСТу

        public string SelectedExecutionFlange;

        public double ExrcuteAtk2618593B; //Выборка толщины заглушек поворотных из ГОСТа
        public double ExrcuteAtk2618593BNonStandart; //Выборка толщины заглушек поворотных пользователем
        public double ExecuteAtk242000290B; //Выборка толщины заглушек или крышек из ГОСТа
        public double ExecuteAtk242000290BNonStandart; //Выборка толщины заглушек или крышек пользователем

        public double ExecuteStandartWashers; //Выборка толщины стандартных шайб
        public double ExecuteNonStandartWashers; //Выборка толщины не стандартных шайб введенных пользователем

        public double ExecuteNonStandartGasket; //Выборка нестандартной толщины прокладки пользователем
        public double ExecuteOvalGasket; //Выборка стандартных овальных прокладок
        public double ExecuteOctagonalGasket; //Выборка стандартных восьмигранных прокладок

        public double? InResultPNuts(string getPNuts) => new DbNutsOst26_2041_96().ExtractThicknessPLarge(getPNuts); //Выборка из ОСТа шага резьбы гаек
        public double? InResultHNuts(string getHNuts) => new DbNutsOst26_2041_96().ExtractThicknessHLarge(getHNuts); //Выборка из ОСТа высоты гаек

        public string StandartPlugsChecked;
        public string NonStandartPlugsChecked;

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

            StandartPlugsChecked = ReceiptAndDistributionOfDataCheckBox["StandartPlugsChecked"].ToString();
            NonStandartPlugsChecked = ReceiptAndDistributionOfDataCheckBox["NonStandartPlugsChecked"].ToString();

            ////Выборка из базы гаек шага резьбы 
            //InResultPNuts = new DbNutsOst26_2041_96().ExtractThicknessPLarge(SelectedTheard);
            ////Выборка из базы гаек высоты шайбы
            //InResultHNuts = new DbNutsOst26_2041_96().ExtractThicknessHLarge(SelectedTheard);

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

            if (ReceiptAndDistributionOfDataCheckBox["StandartPlugsChecked"] is true)
            {
                ExecuteAtk242000290B = new DbCapsATK24_200_02_90().Executedb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartPlugsFromComboBox"].ToString());
                ExecuteAtk242000290BNonStandart = 0;


            }
            else if (ReceiptAndDistributionOfDataCheckBox["NonStandartPlugsChecked"] is true)
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

        public string ResultOutBaseAllGosts()
        {
            #region Сбор данных для расчета по ГОСТ 33259

            if (ReceiptAndDistributionOfDatas["SelectionGostFromCombobox"].ToString() == "ГОСТ 33259-2015 Ряд 1")
            {
                var inResultb1 = new DbWorkGost33259().ExecutionThicknessFlangeb1(SelectedPn, SelectedDn); //Получение из базы толщины тарелки Тип 11
                var inResultnType1 = new DbWorkGost33259().ExecutionThicknessFlangen_type1(SelectedPn, SelectedDn);//Получение из базы кол-во отверстий под шпильки Тип 11
                var inResulth1 = new DbExecutionGost33259().ExecutionGost33259DF(SelectedPn, SelectedDn);
                var inResulth2 = new DbExecutionGost33259().ExecutionGost33259CE(SelectedPn, SelectedDn);
                var inResulth4 = new DbExecutionGost33259().ExecutionGost33259L(SelectedPn, SelectedDn);
                var inResulth5 = new DbExecutionGost33259().ExecutionGost33259M(SelectedPn, SelectedDn);
                //Выборка размера гайки для фланцев
                SelectedTheard = new DbWorkGost33259().ExecutionThicknessFlangeTheard1(SelectedPn, SelectedDn);

                var fromReceiptAndDistribution = new Dictionary<string, object>
                {
                    {"inResultb1", inResultb1}, {"inResultPNuts", InResultPNuts(SelectedTheard)}, {"inResultHNuts", InResultHNuts(SelectedTheard)}, {"ExrcuteAtk2618593b", ExrcuteAtk2618593B},
                    {"ExrcuteAtk2618593bNonStandart", ExrcuteAtk2618593BNonStandart}, {"ExecuteAtk242000290b", ExecuteAtk242000290B},
                    {"ExecuteAtk242000290bNonStandart", ExecuteAtk242000290BNonStandart}, {"ExecuteNonStandartWashers", ExecuteNonStandartWashers},
                    {"ExecuteStandartWashers", ExecuteStandartWashers}, {"ExecuteOvalGasket", ExecuteOvalGasket}, {"inResulth1", inResulth1}, {"inResulth2", inResulth2},
                    {"inResulth4", inResulth4}, {"inResulth5", inResulth5}, {"ExecuteOctagonalGasket", ExecuteOctagonalGasket}, {"ExecuteNonStandartGasket", ExecuteNonStandartGasket},
                    {"SelectedExecutionFlange", SelectedExecutionFlange}, {"StandartPlugsChecked", StandartPlugsChecked}, {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                    {"MaterialStudFromCombobox", ReceiptAndDistributionOfDatas["MaterialStudFromCombobox"]}, {"ExecutionStudFromCombobox", ReceiptAndDistributionOfDatas["ExecutionStudFromCombobox"]},
                    {"SelectedTheard", SelectedTheard},

                };
                string resultInMainWindow = new StandartGost33259().StandartGosts33259(fromReceiptAndDistribution);
                return resultInMainWindow;
            }

            return string.Empty;

            #endregion
        }
    }
}