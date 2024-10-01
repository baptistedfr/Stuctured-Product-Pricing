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
namespace InterfaceProducts
{
    public partial class Interface : Form
    {
        private ParamsManager paramsManager;
        private OptionManager optionManager;
        public Interface()
        {

            InitializeComponent();
            paramsManager = new ParamsManager(new System.Windows.Forms.TextBox[] { textBoxStrike1, textBoxStrike2, textBoxStrike3, textBoxStrike4 },
                                          new Label[] { labelStrike1, labelStrike2, labelStrike3, labelStrike4},
                                          textBoxMaturity, textBoxBinary, labelBinary, textBoxBarrier, labelBarrier);
            optionManager = new OptionManager();

        }

        private void price_Click(object sender, EventArgs e)
        {
            plotView1.Model = null;  // Assigner un modèle nul pour vider l'affichage
            dataGridViewGrecs.Rows.Clear();    // Supprimer toutes les lignes
            dataGridViewGrecs.Columns.Clear(); // Supprimer toutes les colonnes
            labelPrix.Text = "Prix : "; // On réinitialise le Prix
            labelCF.Text = "Close Formula : "; // On réinitialise le Prix

            // On regarde si les paramètres sont bien renseignés
            if (!optionManager.CheckOptionSelected(comboBoxOptions.SelectedItem) ||
            !paramsManager.CheckVisibleStrikeValues() ||
            !paramsManager.CheckMaturityValues() || 
            !paramsManager.CheckBinary() ||
            !paramsManager.CheckBarrier())
            {
                return;
            }

            string? selectedOption = comboBoxOptions.SelectedItem.ToString();
            MessageBox.Show("Vous avez sélectionné : " + selectedOption);
            IDerives derive = optionManager.CreateDerive(selectedOption, paramsManager.GetStrikeValues(), textBoxMaturity.Text, textBoxBinary.Text, textBoxBarrier.Text);

            double spot = Convert.ToDouble(textBoxSpot.Text);
            double vol = Convert.ToDouble(textBoxVolatility.Text) / 100;
            var market = new Market("AAPL", VolatilityType.Cste);
            market.Initialize(vol);
            MonteCarloSimulator mc = new MonteCarloSimulator(derive, market, 100000);
            textBoxRf.Text = (Math.Round(market.Rate*100,2).ToString());
            double price = mc.Price(spot);
            labelPrix.Text += Math.Round(price,2).ToString() + " €";
            labelCF.Text += Math.Round(derive.CloseFormula(market), 2);
            if (!selectedOption.Contains("Call Down") && !selectedOption.Contains("Put Up"))
            {
                CreatePayoffChart(spot, derive, price);
            }

            GenerateGreeks(mc, price, spot);
        }

        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem != null)
            {
                paramsManager.UpdateStrikeVisibility(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBinary(comboBoxOptions.SelectedItem.ToString());
                paramsManager.UpdateBarrier(comboBoxOptions.SelectedItem.ToString());
            }
           
        }
        public void GenerateGreeks(MonteCarloSimulator mc, double price, double spot)
        {
            Dictionary<string, double> greeks = mc.ComputeGreeks(price, spot);

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
                assetPrices[i] = i + Convert.ToInt32(spot/2); 
                payoffs[i] = option.Payoff(assetPrices[i]) - price;
            }

            // Créer le modèle de plot
            var plotModel = new PlotModel { Title = "Graphique du Gain" };

            // Créer une série de lignes pour le payoff
            var series = new LineSeries
            {
                Title = "Gain",
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
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Left, Title = "Gain" });

            // Assigner le modèle au PlotView
            plotView1.Model = plotModel;
        }
    }


}
