namespace ReinforcementLearning
{
    public partial class Simulation : Form
    {
        Map _map;
        List<TransitionReward> _qTable;
        TransitionReward[] _qTablePrevious;
        Random _random = new Random();
        float _learningRate = 0.7F;
        float _discountFactor = 0.9F;
        float _epsilon = 0.7F;
        List<TransitionReward> _qTableVisible => _qTable.Where(x => x.TargetPosition.Type != null).ToList();

        public Simulation()
        {
            InitializeComponent();
            PrepareSimulation();
        }

        private void PrepareSimulation()
        {
            _map = new Map();
            _qTable = TransitionReward.GenerateQTable(_map);
            qTableDataGrid.AutoGenerateColumns = false;
            qTableDataGrid.DataSource = _qTableVisible;
            _qTablePrevious = new TransitionReward[_qTable.Count];
        }

        private void InitializeScenario()
        {
            _map.CurrentPosition = _map.Positions.FirstOrDefault(x => x.Line == _map.Initial.Item1 && x.Column == _map.Initial.Item2);
            _map.PreviousPosition = _map.Positions.FirstOrDefault(x => x.Line == _map.Initial.Item1 && x.Column == _map.Initial.Item2);
            ScreenRefresh();
        }

        private bool HasFinishedScenario()
        {
            return (_map.CurrentPosition.Line == _map.Final.Item1 && _map.CurrentPosition.Column == _map.Final.Item2);
        }

        private bool HasConverged()
        {
            for (int i = 0; i < _qTable.Count; i++)
            {
                if (_qTable[i].Reward == 0 || _qTable[i].Reward != _qTablePrevious[i].Reward)
                {
                    return false;
                }
            }
            return true;
        }

        private void DefineNextMovement()
        {
            MapPosition nextPosition;
            if (_random.NextDouble() > _epsilon)
            {
                nextPosition = GetRandomNextPosition();
            }
            else
            {
                var differentRewards = _map.CurrentPosition.PossibleMovements.DistinctBy(x => x.Reward);
                if (differentRewards.Count() > 1)
                {
                    nextPosition = GetBestNextPosition();
                }
                else
                {
                    nextPosition = GetRandomNextPosition();
                }
            }
            _map.PreviousPosition = _map.CurrentPosition;
            _map.CurrentPosition = nextPosition;
        }

        private MapPosition GetRandomNextPosition()
        {
            var randomIndex = _random.Next(_map.CurrentPosition.PossibleMovements.Count());
            return _map.CurrentPosition.PossibleMovements[randomIndex];
        }

        private MapPosition GetBestNextPosition()
        {
            return _map.CurrentPosition.PossibleMovements.OrderByDescending(x => x.Reward).First();
        }

        private void mapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _map.DrawMap(e.Graphics);
        }

        public void RunSimulation()
        {
            int runs = 0;
            do
            {
                RunNextScenario();
                do
                {
                    RunNextStepSimulation();

                } while (!HasFinishedScenario());
                _qTable.CopyTo(_qTablePrevious);
                //maxRuns--;
                runs++;
            } while (runs < 2000); //!HasConverged() runs < 3000
        }

        private void RunNextScenario()
        {
            InitializeScenario();
        }

        private void RunNextStepSimulation()
        {
            DefineNextMovement();
            var selectedMovement = _qTable.First(x =>
                                                 x.OriginalPosition.Id == _map.PreviousPosition.Id &&
                                                 x.TargetPosition.Id == _map.CurrentPosition.Id
                                                 //x.OriginalPosition.Line == _map.PreviousPosition.Line &&
                                                 //x.OriginalPosition.Column == _map.PreviousPosition.Column &&
                                                 //x.TargetPosition.Line == _map.CurrentPosition.Line &&
                                                 //x.TargetPosition.Column == _map.CurrentPosition.Column
                                                 );
            var targetMapPositionReward = selectedMovement.TargetPosition.Reward;
            var maxTargetQTableReward = _qTable.Where(x => x.OriginalPosition.Id == selectedMovement.TargetPosition.Id).OrderByDescending(x => x.Reward).First().Reward;

            selectedMovement.Reward = selectedMovement.Reward + _learningRate * 
                (targetMapPositionReward + _discountFactor * maxTargetQTableReward - selectedMovement.Reward);

            //CheckButtons();
            ScreenRefresh();
        }

        private void CheckButtons()
        {
            runNextStepButton.Enabled = !HasFinishedScenario();
            runNextScenarioButton.Enabled = !HasConverged();
        }

        private void runFullSimulation_Click(object sender, EventArgs e)
        {
            //runNextStepButton.Enabled = false;
            //runNextScenarioButton.Enabled = false;
            RunSimulation();
            ScreenRefresh();
        }

        private void ScreenRefresh()
        {
            mapPictureBox.Invalidate();
            mapPictureBox.Refresh();
            qTableDataGrid.Refresh();
        }

        private void runNextStepButton_Click(object sender, EventArgs e)
        {
            RunNextStepSimulation();
        }

        private void runNextScenarioButton_Click(object sender, EventArgs e)
        {
            RunNextScenario();
        }
    }
}