using Pricing;
using Pricing.Products;
using Pricing.Volatility.Models;
using Pricing.MonteCarlo;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms; // N'oublie pas d'importer cette biblioth�que
using System.CodeDom;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OxyPlot.Annotations;
using Pricing.Products.Options;
using Microsoft.VisualBasic.Devices;
using Pricing.Products.Autocalls;
using System.Reflection.Emit;
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
                                          new System.Windows.Forms.Label[] { labelStrike1, labelStrike2, labelStrike3, labelStrike4 },
                                          textBoxMaturity, textBoxBinary, labelBinary, textBoxBarrier, labelBarrier,
                                          new System.Windows.Forms.TextBox[] { textBoxBarrier, textBoxBarrierCoupon, textBoxBarrierCapital },
                                          new System.Windows.Forms.Label[] { labelBarrier, labelBarrierCoupon, labelBarrierCapital },
                                          comboBoxFreqObservation, labelFreqObservation
                                          );
            optionManager = new OptionManager(radioButtonAutocall, radioButtonDerive, comboBoxOptions);

            marketManager = new MarketManager(textBoxSpot, textBoxVolatility, textBoxRf, radioButtonAuto, radioButtonManual,
                                    radioButtonVolSto, radioButtonVolCste, radioButtonVolSVI, comboBoxTicker);

        }

        /// <summary>
        /// Fonction qui reset les param�tres de l'affichage
        /// </summary>
        private void ResetUI()
        {
            labelPrix.Visible = true;
            labelCF.Visible = true;
            plotView1.Model = null;
            dataGridViewGrecs.Rows.Clear();
            dataGridViewGrecs.Columns.Clear();
            labelPrix.Text = "Prix : ";
            labelCF.Text = "Close Formula : ";
        }

        /// <summary>
        /// Verifie si tous les param�tres utilisateurs sont bien renseign�s
        /// </summary>
        /// <returns></returns>
        private bool ValidateParameters()
        {
            // On regarde si les param�tres sont bien renseign�s
            if (!optionManager.CheckProduct() ||
            !optionManager.CheckOptionSelected() ||
            !paramsManager.CheckVisibleStrikeValues() ||
            !paramsManager.CheckMaturityValues() ||
            !paramsManager.CheckBinary() ||
            !paramsManager.CheckBarrier() ||
            !paramsManager.CheckAutocall() ||
            !marketManager.CheckRadioButton() ||
            !marketManager.CheckMarket() ||
            !marketManager.CheckTicker())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Pricing d'options et de strat�gies vanilles
        /// </summary>
        private void price_Click(object sender, EventArgs e)
        {
            ResetUI(); // On reset les param�tres
            if (ValidateParameters() == false) // V�rification des param�tres
            {
                return;
            }
            IDerives derive = optionManager.CreateDerive(paramsManager.GetStrikeValues(), textBoxMaturity.Text, textBoxBinary.Text, textBoxBarrier.Text); // On cr�e le d�riv�
            Market market = marketManager.CreateMarket(); // Cr�ation du march�
            MonteCarloSimulator mc = new MonteCarloSimulator(derive, market, 1000000); // On instancie la simulation de monte carlo
            if (radioButtonAuto.Checked)
            {
                marketManager.ActualiseMarket(market); // Actualisation des param�tres pour le march� automatique
            }
            string selectedOption = comboBoxOptions.SelectedItem.ToString();
            (double price, double confidenceInterval) = mc.Price(); // Calcul des prix de l'option avec MC et IC
            labelPrix.Text += Math.Round(price, 2).ToString() + " � +/- " + Math.Round(confidenceInterval, 3) + " �"; // Affichage du prix avec MC
            double closePrice = derive.CloseFormula(market); // Calcul du prix ferme 
            labelCF.Text += Math.Round(closePrice, 2) + " �"; // Affichage du prix en formule ferm�
            if (!selectedOption.Contains("Call Down") && !selectedOption.Contains("Put Up")) 
            {
                CreatePayoffChart(market.Spot, derive, price); // Affichage du graphique des P&L
            }
            GenerateGreeks(mc, price); // G�n�ration des grecs
        }

        /// <summary>
        /// Cas o� l'on souhaite pricer le coupon d'un autocall
        /// </summary>
        private void buttonAutocall_Click(object sender, EventArgs e)
        {
            ResetUI();
            if (ValidateParameters() == false)
            {
                return;
            }
            labelPrix.Visible = false;
            labelCF.Visible = false;// On rend invisible prix

            // Cr�ation de l'autocall
            Autocall autocall = optionManager.CreateAutocall(textBoxMaturity.Text, comboBoxFreqObservation.SelectedItem.ToString(), textBoxBarrier.Text, textBoxBarrierCoupon.Text, textBoxBarrierCapital.Text);
            Market market = marketManager.CreateMarket(); // Creation du march�
            MonteCarloSimulator mc = new MonteCarloSimulator(autocall, market, 1000000);
            if (radioButtonAuto.Checked)
            {
                marketManager.ActualiseMarket(market);
            }
            double coupon = mc.FindCouponAutocall(); // On trouve le coupon
            textBoxBinary.Text = (coupon.ToString()); // On affiche le coupon
            GenerateGreeks(mc, 100);
        }
        /// <summary>
        /// S�lection d'un produit
        /// </summary>
        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem != null) // Lorsque le produit s�lectionner change, on update la visibilit� des param�tres
            {
                paramsManager.UpdateStrikeVisibility(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBinary(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBarrier(comboBoxOptions.SelectedItem.ToString(), radioButtonAutocall.Checked);
            }

        }
        /// <summary>
        /// Changement de type de march�
        /// </summary>
        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            marketManager.UpdateMarket(radioButtonAutocall.Checked);
        }
        /// <summary>
        /// Changement de type de march�
        /// </summary>
        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            marketManager.UpdateMarket(radioButtonAutocall.Checked);
        }
        /// <summary>
        /// Changement de type de vol
        /// </summary>
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
        /// <summary>
        /// Changement de type de vol
        /// </summary>
        private void radioButtonVolSVI_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVolSVI.Checked)
            {
                textBoxVolatility.Text = "";
                textBoxVolatility.Enabled = false;
            }
            else
            {
                textBoxVolatility.Enabled = true;
            }
        }
        /// <summary>
        /// Changement de type de produit (Autocall / D�riv�)
        /// </summary>
        private void radioButtonAutocall_CheckedChanged(object sender, EventArgs e)
        {
            optionManager.UpdateProduct(price, buttonAutocall, textBoxSpot, comboBoxTicker, radioButtonAuto.Checked, radioButtonVolSto);
        }
        /// <summary>
        /// Changement de type de produit (Autocall / D�riv�)
        /// </summary>
        private void radioButtonDerive_CheckedChanged(object sender, EventArgs e)
        {
            optionManager.UpdateProduct(price, buttonAutocall, textBoxSpot, comboBoxTicker, radioButtonAuto.Checked, radioButtonVolSto);
        }
        /// <summary>
        /// Changement de produit s�lectionner
        /// </summary>
        private void comboBoxTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTicker.SelectedItem != null)
            {
                marketManager.UpdateSpot();
            }
        }
        /// <summary>
        /// G�n�ration des grecs et update du dataGrid
        /// </summary>
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
        /// <summary>
        /// Cr�ation de la visualisation du P&L
        /// </summary>
        private void CreatePayoffChart(double spot, IDerives option, double price)
        {
            double[] assetPrices = new double[Convert.ToInt32(spot)]; 
            double[] payoffs = new double[Convert.ToInt32(spot)]; 
            BarrierOption? barrierOption = option as BarrierOption;

            for (int i = 0; i < assetPrices.Length; i++) // Calcul du P&L pour chaque spot final
            {
                if (barrierOption != null)
                {
                    bool no = barrierOption.BarrierOut(i + Convert.ToInt32(spot / 2)); // On actualise la barriere
                }
                assetPrices[i] = i + Convert.ToInt32(spot / 2);
                payoffs[i] = option.Payoff(assetPrices[i]) - price;
            }

            var plotModel = new PlotModel { Title = "Graphique du P&L en fonction du prix" };

            // Cr�ation d'une s�rie pour le payoff
            var series = new LineSeries
            {
                Title = "P&L",
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Red
            };

            // Ajout des points au graphique
            for (int i = 0; i < assetPrices.Length; i++)
            {
                series.Points.Add(new DataPoint(assetPrices[i], payoffs[i]));
            }
            plotModel.Series.Add(series);

            // Ajout d'une ligne horizontale en pointill�s noirs � y = 0 repr�sentant le P&L 0
            var zeroLine = new LineAnnotation
            {
                Type = LineAnnotationType.Horizontal,
                Y = 0, 
                Color = OxyColors.Black,
                LineStyle = LineStyle.Dash 
            };
            plotModel.Annotations.Add(zeroLine);

            if (barrierOption != null)
            {
                // On va plot la barri�re
                var barrierLine = new LineAnnotation
                {
                    Type = LineAnnotationType.Vertical,
                    X = barrierOption.Barrier, 
                    Color = OxyColors.Green,
                    LineStyle = LineStyle.Dash 
                };
                plotModel.Annotations.Add(barrierLine);
            }
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Title = "S" });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "P&L" });
            plotView1.Model = plotModel;
        }

       
    }
}
