using StudCalculator.Data.DBWork;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData
{
    internal class ReceiptAndDistributionData
    {

        private Dictionary<string, object> ReceiptAndDistributionOfDatas { get; }  //Получение всех переменных который ввел пользователь        
        private Dictionary<string, bool> ReceiptAndDistributionOfDataCheckBox { get; }  //Получение всех данных о дополнительных условиях для расчета

        #region Объявление переменных которые используются во всех гостах

        private string SelectedPn { get; } //Выборка давления пользователем
        private string SelectedDn { get; } //Выборка диаметра фланцев пользователем
        private string SelectedTheard { get; set; } //Выборка диаметра шпилек по ГОСТу
        private double SelectedFlangeN { get; set; } //Получение из базы кол-во отверстий под шпильки
        private string SelectedExecutionFlange { get; }  //Получение исполнений ГОСТов и тд. введенных пользователем
        private bool StandartPlugsChecked { get; }  //Получение включен ли чекбокс на стандартные крышки
        private bool NonStandartPlugsChecked { get; }  //Получение включен ли чекбокс на нестандартные крышки
        private string ResultSumFlange { get; set; }  //Формула расчета кол-ва шпилек
        private string SelectedFromCombobox { get; }

        private double InResultPNuts(string getPNuts) => new DbNutsOst26_2041_96().ExtractThicknessPLarge(getPNuts); //Выборка из ОСТа шага резьбы гаек
        private double InResultHNuts(string getHNuts) => new DbNutsOst26_2041_96().ExtractThicknessHLarge(getHNuts); //Выборка из ОСТа высоты гаек
        private double ResultInMainWindow => ResultOutBaseAllGosts();  //Получение расчета толщины тарелки фланцев разных гостов
        private double[] ExrcuteAtkStandartOrNot2618593B => StandartOrNotRotaryPlugsChecked();  //Выборка толщины заглушек в зависимости от условий        
        private double[] ExecuteAtkStandartOrNot242000290B => StandartOrNotPlugsChecked();  //Выборка заглушек и крышек в зависимости от условий        
        private double[] ExecutedStandartOrNotWashers => ExecuteStandartOrNotWashers();  //Выборка шайб в зависимости от условий        
        private double[] ExecutedOvalAndOctagonalOrNonStandartGasket => ExecuteOvalAndOctagonalOrNonStandartGasket();  //Выборка прокладок в зависимости от условий
        public string ResultAllGostAndNonGosts { get => ResultAllGostAndNonGost(); }  //Получение результатов расчета

        #endregion


        public ReceiptAndDistributionData(Dictionary<string, object> data, Dictionary<string, bool> dataCheckBox)
        {
            ReceiptAndDistributionOfDatas = data;
            ReceiptAndDistributionOfDataCheckBox = dataCheckBox;

            #region Получения значений для всех ГОСТов

            SelectedPn = data["PnSelectedFromComboBox"].ToString();  //Получения значения PN            
            SelectedDn = data["DnSelectedFromComboBox"].ToString();  //Получение значения DN            
            SelectedExecutionFlange = data["ExecutionFromComboBox"].ToString();  //Получение исполнений ГОСТов и тд. введенных пользователем
            StandartPlugsChecked = dataCheckBox["StandartPlugsChecked"];  //Получение включен ли чекбокс на стандартные крышки
            NonStandartPlugsChecked = dataCheckBox["NonStandartPlugsChecked"];  //Получение включен ли чекбокс на нестандартные крышки
            SelectedFromCombobox = data["SelectionGostFromCombobox"].ToString();

            #endregion
        }

        #region Передача для расчета данных со всех ГОСТов и нестандартных фланцев

        private string ResultAllGostAndNonGost()
        {
            var resultToResultInViewModels = new Dictionary<string, object>
            {
                {"B", ResultInMainWindow},
                {"MaterialStudFromCombobox", ReceiptAndDistributionOfDatas["MaterialStudFromCombobox"]},
                {"ExecutionStudFromCombobox", ReceiptAndDistributionOfDatas["ExecutionStudFromCombobox"]},
                {"SelectedTheard", SelectedTheard},
                {"ExrcuteAtk2618593b", ExrcuteAtkStandartOrNot2618593B[0]},
                {"ExrcuteAtk2618593bNonStandart", ExrcuteAtkStandartOrNot2618593B[1]},
                {"ExecuteAtk242000290b", ExecuteAtkStandartOrNot242000290B[0]},
                {"ExecuteAtk242000290bNonStandart", ExecuteAtkStandartOrNot242000290B[1]},
                {"ExecuteStandartWashers", ExecutedStandartOrNotWashers[0]},
                {"ExecuteNonStandartWashers", ExecutedStandartOrNotWashers[1]},
                {"ExecuteOvalGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[0]},
                {"ExecuteOctagonalGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[1]},
                {"ExecuteNonStandartGasket", ExecutedOvalAndOctagonalOrNonStandartGasket[2]},
                {"inResultPNuts", InResultPNuts(SelectedTheard)},
                {"inResultHNuts", InResultHNuts(SelectedTheard)},
            };

            //Формула расчета кол-ва шпилек            
            ResultSumFlange =
                Convert.ToString(
                    SelectedFlangeN *
                    Convert.ToDouble(ReceiptAndDistributionOfDatas["SumFlangeTextRead"]), CultureInfo.InvariantCulture);

            string resultInMainWindow = new ResultInViewModel.ResultInViewModel(resultToResultInViewModels).ReturnResultFromLotsman;
            string resultInMainWindowPlusSumFlange = $"{resultInMainWindow} - кол-во шпилек {ResultSumFlange}шт.";

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
                return new[] { exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart };
            }

            if (ReceiptAndDistributionOfDataCheckBox["NonStandartRotaryPlugsChecked"] is true)
            {
                double exrcuteAtk2618593BNonStandart = Convert.ToDouble(ReceiptAndDistributionOfDatas["NonStandartRotaryPlugsTextRead"]);
                double exrcuteAtk2618593B = 0;
                return new[] { exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart };
            }

            else
            {
                double exrcuteAtk2618593B = 0;
                double exrcuteAtk2618593BNonStandart = 0;
                return new[] { exrcuteAtk2618593B, exrcuteAtk2618593BNonStandart };
            }
        }

        #endregion

        #region Если используются заглушки или крышки

        private double[] StandartOrNotPlugsChecked()
        {
            if (StandartPlugsChecked is true)
            {
                double executeAtk242000290B = new DbCapsAtk242000290().Executedb(SelectedPn, SelectedDn,
                    ReceiptAndDistributionOfDatas["StandartPlugsFromComboBox"].ToString());
                double executeAtk242000290BNonStandart = 0;

                return new[] { executeAtk242000290B, executeAtk242000290BNonStandart };
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
                double executeStandartWashers = new DbStandartWashersOST26204296().StandartWashers(SelectedTheard);
                double executeNonStandartWashers = 0;
                return new[] { executeStandartWashers, executeNonStandartWashers };
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
                return new[] { executeOvalGasket, executeNonStandartGasket, executeOctagonalGasket };
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

        private double ResultOutBaseAllGosts()
        {
            #region Сбор данных для расчета по ГОСТ 33259

            switch (SelectedFromCombobox)
            {
                case "ГОСТ 33259-2015 Ряд 1":
                    {
                        var inResultb1 = new DbWorkGost33259().ExecutionThicknessFlangeb1(SelectedPn, SelectedDn); //Получение из базы толщины тарелки Тип 11
                        var inResulth1 = new DbExecutionGost33259().ExecutionGost33259DF(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения
                        var inResulth2 = new DbExecutionGost33259().ExecutionGost33259CE(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения
                        var inResulth4 = new DbExecutionGost33259().ExecutionGost33259L(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения
                        var inResulth5 = new DbExecutionGost33259().ExecutionGost33259M(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения
                        SelectedFlangeN = new DbWorkGost33259().ExecutionThicknessFlangen_type1(SelectedPn, SelectedDn); //Получение из базы кол-во отверстий под шпильки               
                        SelectedTheard = new DbWorkGost33259().ExecutionThicknessFlangeTheard1(SelectedPn, SelectedDn);  //Выборка размера гайки для фланцев

                        var fromReceiptAndDistribution = new Dictionary<string, object>
                        {
                            {"inResultb1", inResultb1},
                            {"inResulth1", inResulth1}, {"inResulth2", inResulth2},
                            {"inResulth4", inResulth4}, {"inResulth5", inResulth5},
                            {"StandartPlugsChecked", StandartPlugsChecked},
                            {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                            {"SelectedExecutionFlange", SelectedExecutionFlange},
                        };
                        
                        double resultInMainWindow = new StandartGost33259(fromReceiptAndDistribution).B;

                        return resultInMainWindow;
                    }

                case "ГОСТ 28759.3-90":
                    {
                        var inResultB = new DbGost28759_3_90().ExecutedBFromGost28759390(SelectedPn, SelectedDn);  //Получение из базы толщины тарелки
                        SelectedFlangeN = new DbGost28759_3_90().ExecutionThicknessFlangeN(SelectedPn, SelectedDn);  //Получение из базы кол-во отверстий под шпильки                
                        SelectedTheard = new DbGost28759_3_90().ExecutionThicknessFlangeTheard(SelectedPn, SelectedDn);  //Выборка размера гайки для фланцев

                        var fromReceiptAndDistribution = new Dictionary<string, object>
                        {
                            { "inResultB", inResultB },
                            {"StandartPlugsChecked", StandartPlugsChecked},
                            {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                            {"SelectedExecutionFlange", SelectedExecutionFlange},
                        };

                        double resultInMainWindow = new StandartGost28759_3_90(fromReceiptAndDistribution).B;
                        return resultInMainWindow;
                    }

                case "ГОСТ 28759.4-90":
                    {
                        var inResultB = new DbGost28759_4_90().ExecutedBFromGost28759490(SelectedPn, SelectedDn);  //Получение из базы толщины тарелки
                        SelectedFlangeN = new DbGost28759_4_90().ExecutionThicknessFlangeN(SelectedPn, SelectedDn);  //Получение из базы кол-во отверстий под шпильки                
                        SelectedTheard = new DbGost28759_4_90().ExecutionThicknessFlangeTheard(SelectedPn, SelectedDn);  //Выборка размера гайки для фланцев

                        var fromReceiptAndDistribution = new Dictionary<string, object>
                        {
                            { "inResultB", inResultB },
                            {"StandartPlugsChecked", StandartPlugsChecked},
                            {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                            {"SelectedExecutionFlange", SelectedExecutionFlange},
                        };

                        double resultInMainWindow = new StandartGost28759_4_90(fromReceiptAndDistribution).B;
                        return resultInMainWindow;
                    }

                case "АТК-26-18-13-96":
                    {
                        var inResultB = new DbAtk26_18_13_96().ExecutionThicknessFlangeB(SelectedPn, SelectedDn); //Получение из базы толщины тарелки Тип 11
                        var inResultH1 = new DbAtk26_18_13_96().ExecutionGost26181396H1(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения
                        var inResultH2 = new DbAtk26_18_13_96().ExecutionGost26181396H2(SelectedPn, SelectedDn);  //Получение из базы толщины в зависимости от исполнения                     
                        SelectedFlangeN = new DbAtk26_18_13_96().ExecutionThicknessFlangeN(SelectedPn, SelectedDn); //Получение из базы кол-во отверстий под шпильки               
                        SelectedTheard = new DbAtk26_18_13_96().ExecutionThicknessFlangeTheard(SelectedPn, SelectedDn);  //Выборка размера гайки для фланцев

                        var fromReceiptAndDistribution = new Dictionary<string, object>
                        {
                            {"inResultb1", inResultB},
                            {"inResulth1", inResultH1}, {"inResulth2", inResultH2},                           
                            {"StandartPlugsChecked", StandartPlugsChecked},
                            {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                            {"SelectedExecutionFlange", SelectedExecutionFlange},
                        };

                        double resultInMainWindow = new StandartAtk26_18_13_96(fromReceiptAndDistribution).B;

                        return resultInMainWindow;
                    }

                default:
                    return double.NaN;
            }

            #endregion
        }

        #endregion


    }
}