using Pricing;
using Pricing.Products;
using Pricing.Volatility.Models;
using Pricing.MonteCarlo;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms; // N'oublie pas d'importer cette bibliothèque
using System.CodeDom;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OxyPlot.Annotations;
using Pricing.Products.Options;
using Microsoft.VisualBasic.Devices;
namespace InterfaceProducts
{
    public partial class Interface : Form
    {
        private ParamsManager paramsManager;
        private OptionManager optionManager;
        private MarketManager marketManager;
        public Interface()
        {

            InitializeComponent();
            paramsManager = new ParamsManager(new System.Windows.Forms.TextBox[] { textBoxStrike1, textBoxStrike2, textBoxStrike3, textBoxStrike4 },
                                          new Label[] { labelStrike1, labelStrike2, labelStrike3, labelStrike4 },
                                          textBoxMaturity, textBoxBinary, labelBinary, textBoxBarrier, labelBarrier,
                                          new System.Windows.Forms.TextBox[] { textBoxBarrier, textBoxBarrierCoupon, textBoxBarrierCapital },
                                          new Label[] { labelBarrier, labelBarrierCoupon, labelBarrierCapital },
                                          comboBoxFreqObservation,labelFreqObservation
                                          );
            optionManager = new OptionManager(radioButtonAutocall, radioButtonDerive, comboBoxOptions);

            marketManager = new MarketManager(textBoxSpot, textBoxVolatility, textBoxRf, radioButtonAuto, radioButtonManual, radioButtonVolSto, radioButtonVolCste, radioButtonVolSVI);

        }
        private void ResetUI()
        {
            plotView1.Model = null;
            dataGridViewGrecs.Rows.Clear();
            dataGridViewGrecs.Columns.Clear();
            labelPrix.Text = "Prix : ";
            labelCF.Text = "Close Formula : ";
        }
        private bool ValidateParameters()
        {
            // On regarde si les paramètres sont bien renseignés
            if (!optionManager.CheckProduct() ||
            !optionManager.CheckOptionSelected() ||
            !paramsManager.CheckVisibleStrikeValues() ||
            !paramsManager.CheckMaturityValues() ||
            !paramsManager.CheckBinary() ||
            !paramsManager.CheckBarrier() ||
            !paramsManager.CheckAutocall() ||
            !marketManager.CheckRadioButton() ||
            !marketManager.CheckMarket())
            {
                return false;
            }
            return true;
        }
      
        private void price_Click(object sender, EventArgs e)
        {
            ResetUI();
            if (ValidateParameters() == false)
            {
                return;
            }
            IDerives derive = optionManager.CreateDerive(paramsManager.GetStrikeValues(), textBoxMaturity.Text, textBoxBinary.Text, textBoxBarrier.Text);

            Market market = marketManager.CreateMarket();

            MonteCarloSimulator mc = new MonteCarloSimulator(derive, market, 100000);
            if (radioButtonAuto.Checked)
            {
                marketManager.ActualiseMarket(market);
            }
            string selectedOption = comboBoxOptions.SelectedItem.ToString();
            (double price, double confidenceInterval) = mc.Price();
            labelPrix.Text += Math.Round(price, 2).ToString() + " € +/- " + Math.Round(confidenceInterval, 3) + " €";
            double closePrice = derive.CloseFormula(market);
            labelCF.Text += Math.Round(closePrice, 2) + " €";
            if (!selectedOption.Contains("Call Down") && !selectedOption.Contains("Put Up"))
            {
                CreatePayoffChart(market.Spot, derive, price);
            }
            //ConvergenceChart(closePrice, tabPrices);
            GenerateGreeks(mc, price);
        }
        private void buttonAutocall_Click(object sender, EventArgs e)
        {
            ResetUI();
            if (ValidateParameters() == false)
            {
                return;
            }
            Autocall  autocall = optionManager.CreateAutocall(textBoxMaturity.Text, comboBoxFreqObservation.SelectedItem.ToString(), textBoxBarrier.Text, textBoxBarrierCoupon.Text, textBoxBarrierCapital.Text);

            Market market = marketManager.CreateMarket();

            MonteCarloSimulator mc = new MonteCarloSimulator(autocall, market, 100000);
            if (radioButtonAuto.Checked)
            {
                marketManager.ActualiseMarket(market);
            }
            double coupon = mc.FindCouponAutocall();

            textBoxBinary.Text = (coupon.ToString());
            ////ConvergenceChart(closePrice, tabPrices);
            GenerateGreeks(mc, 100);
        }
        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem != null)
            {
                paramsManager.UpdateStrikeVisibility(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBinary(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBarrier(comboBoxOptions.SelectedItem.ToString(), radioButtonAutocall.Checked);
            }

        }
        public void GenerateGreeks(MonteCarloSimulator mc, double price)
        {
            Dictionary<string, double> greeks = mc.ComputeGreeks();

            dataGridViewGrecs.Columns.Add("Grec", "Grec");
            dataGridViewGrecs.Columns.Add("Valeur", "Valeur");

            // Ajout des valeurs du dictionnaire dans le DataGridView
            foreach (var greek in greeks)
            {
                dataGridViewGrecs.Rows.Add(greek.Key, Math.Round(greek.Value, 2));
            }
            dataGridViewGrecs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewGrecs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            int totalWidth = dataGridViewGrecs.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            int totalHeight = dataGridViewGrecs.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
            totalHeight += dataGridViewGrecs.ColumnHeadersHeight;
            totalWidth += dataGridViewGrecs.RowHeadersWidth;
            dataGridViewGrecs.ClientSize = new Size(totalWidth, totalHeight);
        }
        private void CreatePayoffChart(double spot, IDerives option, double price)
        {
            double[] assetPrices = new double[Convert.ToInt32(spot)]; // Prix de l'actif sous-jacent
            double[] payoffs = new double[Convert.ToInt32(spot)]; // Payoff
            BarrierOption? barrierOption = option as BarrierOption;

            for (int i = 0; i < assetPrices.Length; i++)
            {
                if (barrierOption != null)
                {
                    bool no = barrierOption.BarrierOut(i + Convert.ToInt32(spot / 2)); // On actualise la barriere
                }
                assetPrices[i] = i + Convert.ToInt32(spot / 2);
                payoffs[i] = option.Payoff(assetPrices[i]) - price;
            }

            // Créer le modèle de plot
            var plotModel = new PlotModel { Title = "Graphique du P&L en fonction du prix" };

            // Créer une série de lignes pour le payoff
            var series = new LineSeries
            {
                Title = "P&L",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Red
            };

            // Ajouter les points au graphique
            for (int i = 0; i < assetPrices.Length; i++)
            {
                series.Points.Add(new DataPoint(assetPrices[i], payoffs[i]));
            }
            plotModel.Series.Add(series);

            // Ajouter une ligne horizontale en pointillés noirs à y = 0
            var zeroLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 0, // Position sur l'axe des ordonnées
                Color = OxyColors.Black,
                LineStyle = LineStyle.Dash // Style en pointillés
            };
            plotModel.Annotations.Add(zeroLine);

            if (barrierOption != null)
            {
                // On va plot la barrière
                var barrierLine = new LineAnnotation
                {
                    Type = LineAnnotationType.Vertical,
                    X = barrierOption.Barrier, // Position sur l'axe des ordonnées
                    Color = OxyColors.Green,
                    LineStyle = LineStyle.Dash // Style en pointillés
                };
                plotModel.Annotations.Add(barrierLine);
            }

            // Configurer les axes
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "S" });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "P&L" });

            // Assigner le modèle au PlotView
            plotView1.Model = plotModel;
        }
        private void ConvergenceChart(double closePrice, double[] prices)
        {

            var plotModel = new PlotModel { Title = "Convergence" };

            // Créer une série de lignes pour le payoff
            var series = new LineSeries
            {
                Title = "Monte Carlo",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Blue
            };

            // Ajouter les points au graphique
            for (int i = 0; i < prices.Length; i++)
            {
                series.Points.Add(new DataPoint(i, prices[i]));
            }
            plotModel.Series.Add(series);

            // Ajouter une ligne horizontale en pointillés noirs à y = 0
            var closePriceLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = closePrice, // Position sur l'axe des ordonnées
                Color = OxyColors.Red,
                LineStyle = LineStyle.Dash // Style en pointillés
            };
            plotModel.Annotations.Add(closePriceLine);


            // Configurer les axes
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "Nombre Simulations" });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "Prix" });

            // Assigner le modèle au PlotView
            //plotViewConvergence.Model = plotModel;
        }
        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            marketManager.UpdateMarket();
        }
        private void radioButtonVolSto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVolSto.Checked)
            {
                textBoxVolatility.Text = "";
                textBoxVolatility.Enabled = false;
            }
            else
            {
                textBoxVolatility.Enabled = true;
            }
        }

        private void radioButtonAutocall_CheckedChanged_1(object sender, EventArgs e)
        {
            optionManager.UpdateProduct(price,buttonAutocall, textBoxSpot);
        }

        private void radioButtonDerive_CheckedChanged_1(object sender, EventArgs e)
        {
            optionManager.UpdateProduct(price, buttonAutocall, textBoxSpot);
        }
    }
}
