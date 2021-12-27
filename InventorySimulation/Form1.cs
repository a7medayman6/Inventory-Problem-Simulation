using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryTesting;
using InventoryModels;
using System.IO;
namespace InventorySimulation
{
    public partial class Form1 : Form
    {
        public string[] lines;
        public SimulationSystem Simulation;
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
            // runing in debug mode ?
            lines = File.ReadAllLines(Constants.FileNames.TestCase1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Simulation = LoadInputData(lines);
            dataTable = init_form();
            // Assign the table as the data source of the grid view
            simulation_dgv.DataSource = dataTable;
            simulation_dgv.DataSource = dataTable;
        }

        private DataTable init_form()
        {
            // init a new table
            DataTable table = new DataTable();

            // Add the table columns
            table.Columns.Add("Day");
            table.Columns.Add("Cycle");
            table.Columns.Add("Day Within Cycle");
            table.Columns.Add("Beginning Inventory");
            table.Columns.Add("Random Digits For Demand");
            table.Columns.Add("Demand");
            table.Columns.Add("Ending Inventory");
            table.Columns.Add("Shortage Quantity");
            table.Columns.Add("Order Quantity");
            table.Columns.Add("Random Digits For Lead Days");
            table.Columns.Add("Lead Days");
            table.Columns.Add("Days Until Order Arrives");
            Console.WriteLine("INIT FORM!!");

            return table;
        }
 
        public void DisplaySimulation(SimulationSystem Simulation, DataTable dt)
        {
            foreach (SimulationCase simCase in Simulation.SimulationCases)
            {
                DataRow row = dt.NewRow();

                row["Day"] = simCase.Day;
                row["Cycle"] = simCase.Cycle;
                row["Day Within Cycle"] = simCase.DayWithinCycle;
                row["Beginning Inventory"] = simCase.BeginningInventory;
                row["Random Digits For Demand"] = simCase.RandomDemand;
                row["Demand"] = simCase.Demand;
                row["Ending Inventory"] = simCase.EndingInventory;
                row["Shortage Quantity"] = simCase.ShortageQuantity;
                row["Order Quantity"] = simCase.OrderQuantity;
                row["Random Digits For Lead Days"] = simCase.RandomLeadDays;
                row["Lead Days"] = simCase.LeadDays;
                row["Days Until Order Arrives"] = simCase.DaysUntilOrderArrives;

                dt.Rows.Add(row);
            }

            endingavg_t.Text = Simulation.PerformanceMeasures.EndingInventoryAverage.ToString();
            shortageavg_t.Text = Simulation.PerformanceMeasures.ShortageQuantityAverage.ToString();
        }
        public PerformanceMeasures CalculatePerformance(List<SimulationCase> SimCases)
        {
            PerformanceMeasures performanceMeasures = new PerformanceMeasures();

            int ending = 0, shortage = 0;
            foreach (SimulationCase simCase in SimCases)
            {
                ending += simCase.EndingInventory;
                shortage += simCase.ShortageQuantity;
            }

            performanceMeasures.EndingInventoryAverage = (decimal)ending / SimCases.Count;
            performanceMeasures.ShortageQuantityAverage = (decimal)shortage / SimCases.Count;

            return performanceMeasures;
        }
        public SimulationSystem Simulate(SimulationSystem System)
        {
            int Cycle = 1;
            int CyclesDay = 1;
            Random random = new Random();

            for (int i = 1; i <= System.NumberOfDays; i++)
            {
                SimulationCase simCase = new SimulationCase();

                // Days
                simCase.Day = i;
                simCase.Cycle = Cycle;
                simCase.DayWithinCycle = CyclesDay;
                CyclesDay++;

                if (CyclesDay == System.ReviewPeriod + 1)
                    CyclesDay = 1;

                // Starting Conditions
                if (i == 1)
                {
                    simCase.BeginningInventory = System.StartInventoryQuantity;
                    System.PendingOrderQuantity = System.StartOrderQuantity;
                    simCase.DaysUntilOrderArrives = System.StartLeadDays - 1;
                }
                else
                {
                    // beg = yesterday's end
                    simCase.BeginningInventory = System.SimulationCases[System.SimulationCases.Count - 1].EndingInventory;

                    // days until order arrives = yesterday's days - 1
                    simCase.DaysUntilOrderArrives = System.SimulationCases[System.SimulationCases.Count - 1].DaysUntilOrderArrives - 1;
                    simCase.DaysUntilOrderArrives = simCase.DaysUntilOrderArrives < 0 ? 0 : simCase.DaysUntilOrderArrives;

                    // shortage = yesterday's shortage
                    simCase.ShortageQuantity = System.SimulationCases[System.SimulationCases.Count - 1].ShortageQuantity;
                }

                // Supplier Came Through ! 
                // Shortages = 0, DaysUntilArrives = 0, PendingOrderQuantity = 0, 
                if (i > 2 && System.SimulationCases[System.SimulationCases.Count - 2].DaysUntilOrderArrives - 1 == 0)
                {
                    simCase.BeginningInventory += System.PendingOrderQuantity ;
                    System.PendingOrderQuantity = 0;
                    simCase.ShortageQuantity = 0;
                    simCase.DaysUntilOrderArrives = 0;
                }


                // Generate a demand and calc the ending and shortage
                simCase.RandomDemand = random.Next(1, 101);
                simCase.Demand = FindValue(simCase.RandomDemand, System.DemandDistribution);
                simCase.EndingInventory = simCase.Demand > simCase.BeginningInventory ? 0 : simCase.BeginningInventory - simCase.Demand;
                if (i > 2 && System.SimulationCases[System.SimulationCases.Count - 2].DaysUntilOrderArrives - 1 == 0)
                    simCase.EndingInventory -= System.SimulationCases[System.SimulationCases.Count - 1].ShortageQuantity;
                simCase.ShortageQuantity += simCase.Demand > simCase.BeginningInventory ? simCase.Demand - simCase.BeginningInventory : 0;

                // Ordering Day
                if (i >= System.ReviewPeriod && i % System.ReviewPeriod == 0)
                {
                    // Calculate the needed order quantity, and set the pending quantity
                    simCase.OrderQuantity = System.OrderUpTo - simCase.EndingInventory + simCase.ShortageQuantity;
                    System.PendingOrderQuantity = simCase.OrderQuantity;

                    // Generate lead days and calc days until order arrives
                    simCase.RandomLeadDays = random.Next(1, 10);
                    simCase.LeadDays = FindValue(simCase.RandomLeadDays, System.LeadDaysDistribution);
                    simCase.DaysUntilOrderArrives = simCase.LeadDays;

                    // New Cycle!
                    Cycle++;
                }

                // add the case to the list of cases
                System.SimulationCases.Add(simCase);
            }
            return System;
        }

        public int FindValue(int rand, List<Distribution> distributions)
        {
            foreach (Distribution dist in distributions)
                if (rand <= dist.MaxRange && rand >= dist.MinRange)
                    return dist.Value;
            return -1;

        }
        private SimulationSystem LoadInputData(string[] lines)
        {
            SimulationSystem System = new SimulationSystem();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "OrderUpTo")
                    System.OrderUpTo = int.Parse(lines[i + 1]);
                else if (lines[i] == "ReviewPeriod")
                    System.ReviewPeriod = int.Parse(lines[i + 1]);
                else if (lines[i] == "StartInventoryQuantity")
                    System.StartInventoryQuantity = int.Parse(lines[i + 1]);
                else if (lines[i] == "StartLeadDays")
                    System.StartLeadDays = int.Parse(lines[i + 1]);
                else if (lines[i] == "StartOrderQuantity")
                    System.StartOrderQuantity = int.Parse(lines[i + 1]);
                else if (lines[i] == "NumberOfDays")
                    System.NumberOfDays = int.Parse(lines[i + 1]);
                else if (lines[i] == "DemandDistribution")
                {
                    List<Distribution> DemandDistribution = new List<Distribution>();
                    for (int j = 0; j < 5; j++)
                    {
                        i++;

                        string[] row = lines[i].Trim().Replace(" ", String.Empty).Split(',');

                        Distribution dist = AssignDistribution(row, j, DemandDistribution);

                        // add the dist to the list
                        DemandDistribution.Add(dist);
                    }
                    System.DemandDistribution = DemandDistribution;
                }
                else if (lines[i] == "LeadDaysDistribution")
                {
                    List<Distribution> LeadDaysDistribution = new List<Distribution>();
                    for (int j = 0; j < 3; j++)
                    {
                        i++;

                        string[] row = lines[i].Trim().Replace(" ", String.Empty).Split(',');

                        Distribution dist = AssignDistribution(row, j, LeadDaysDistribution);

                        // add the dist to the list
                        LeadDaysDistribution.Add(dist);
                    }
                    System.LeadDaysDistribution = LeadDaysDistribution;
                }
            }
            return System;

        }

        private Distribution AssignDistribution(string[] row, int j, List<Distribution> DistList)
        {
            Distribution Dist = new Distribution();

            // get the probability
            decimal prob = decimal.Parse(row[1]) * 100;

            // get the value
            Dist.Value = int.Parse(row[0]);

            // assign the probability
            Dist.Probability = prob;

            // assign the cummulative prob, for the first val = prob, for others = last cumm prob + prob
            Dist.CummProbability = j == 0 ? (int)prob : DistList[j - 1].CummProbability + (int)prob;

            // assign the min range, for the first val = 1, for others = last max + 1
            Dist.MinRange = j == 0 ? 1 : DistList[j - 1].MaxRange + 1;

            // assign the max range, for the first val = prob, for others = cumm prob
            Dist.MaxRange = j == 0 ? (int)prob : (int)Dist.CummProbability;

            return Dist;
        }

        private void simulate_Click_1(object sender, EventArgs e)
        {
            // Initialize the input data
            orderupto_t.Text = Simulation.OrderUpTo.ToString();
            reviewperiod_t.Text = Simulation.ReviewPeriod.ToString();
            startinventoryq_t.Text = Simulation.StartInventoryQuantity.ToString();
            startleaddays_t.Text = Simulation.StartLeadDays.ToString();
            startorderq_t.Text = Simulation.StartOrderQuantity.ToString();
            numberofdays_t.Text = Simulation.NumberOfDays.ToString();


            Simulate(Simulation);
            Simulation.PerformanceMeasures = CalculatePerformance(Simulation.SimulationCases);

            DisplaySimulation(Simulation, dataTable);

            MessageBox.Show(TestingManager.Test(Simulation, Constants.FileNames.TestCase1));
        }
    }
}
