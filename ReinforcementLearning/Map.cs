namespace ReinforcementLearning
{
    public class Map
    {
        public List<MapPosition> Positions { get; set; }
        public Tuple<int, int> Initial;
        public Tuple<int, int> Final;
        public List<Tuple<int, int>> Obstacles = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> Free = new List<Tuple<int, int>>();
        public MapPosition CurrentPosition { get; set; }
        public MapPosition PreviousPosition { get; set; }

        public Map()
        {
            Positions = new List<MapPosition>();
            CreateMap();
        }

        public void DefinePossibleMovements()
        {
            MapPosition possiblePosition;
            foreach (var position in Positions)
            {
                position.PossibleMovements = new List<MapPosition>();
                if (position.Line > 1)
                {
                    possiblePosition = Positions.First(x => x.Line == (position.Line - 1) && x.Column == position.Column);
                    if (possiblePosition.Type != null)
                        position.PossibleMovements.Add(possiblePosition);
                }
                if (position.Column > 1)
                {
                    possiblePosition = Positions.First(x => x.Line == position.Line && x.Column == (position.Column - 1));
                    if (possiblePosition.Type != null)
                        position.PossibleMovements.Add(possiblePosition);
                }
                if (position.Column < 12)
                {
                    possiblePosition = Positions.First(x => x.Line == position.Line && x.Column == (position.Column + 1));
                    if (possiblePosition.Type != null)
                        position.PossibleMovements.Add(possiblePosition);
                }
                if (position.Line < 10)
                {
                    possiblePosition = Positions.First(x => x.Line == (position.Line + 1) && x.Column == position.Column);
                    if (possiblePosition.Type != null)
                        position.PossibleMovements.Add(possiblePosition);
                }
            }
        }

        public void DrawMap(Graphics g)
        {
            Brush brush;
            for (int line = 1; line <= 10; line++)
            {
                for (int column = 1; column <= 12; column++)
                {
                    var positionType = GetPositionType(line, column);

                    switch (positionType)
                    {
                        case PositionType.Obstacle:
                            brush = Brushes.Black;
                            break;
                        case PositionType.Inicial:
                            brush = Brushes.PaleVioletRed;
                            break;
                        case PositionType.Final:
                            brush = Brushes.LightGreen;
                            break;
                        case PositionType.Free:
                            brush = Brushes.LightYellow;
                            break;
                        default:
                            brush = Brushes.Transparent;
                            break;
                    }

                    g.FillRectangle(brush, (column - 1) * (50 + 5), (line - 1) * (50 + 5), 50, 50);
                }
            }
            if (CurrentPosition != null)
            {
                g.FillRectangle(Brushes.DeepPink, (CurrentPosition.Column - 1) * (50 + 5), (CurrentPosition.Line - 1) * (50 + 5), 50, 50);
            }
        }

        private void CreateMap()
        {
            DefineMap();
            for (int line = 1; line <= 10; line++)
            {
                for (int column = 1; column <= 12; column++)
                {
                    Positions.Add(new MapPosition(line, column, GetPositionType(line, column)));
                }
            }
            DefinePossibleMovements();
        }

        public PositionType? GetPositionType(int line, int column)
        {
            if (Initial.Item1 == line && Initial.Item2 == column)
            {
                return PositionType.Inicial;
            }
            else if (Final.Item1 == line && Final.Item2 == column)
            {
                return PositionType.Final;
            }
            else if (Obstacles.Any(x => x.Item1 == line && x.Item2 == column))
            {
                return PositionType.Obstacle;
            }
            else if (Free.Any(x => x.Item1 == line && x.Item2 == column))
            {
                return PositionType.Free;
            }
            else
            {
                return null;
            }
        }

        private void DefineMap()
        {
            Initial = new Tuple<int, int>(10, 5);

            Final = new Tuple<int, int>(5, 12);

            Obstacles.Add(new Tuple<int, int>(1, 5));
            Obstacles.Add(new Tuple<int, int>(1, 12));
            Obstacles.Add(new Tuple<int, int>(2, 2));
            Obstacles.Add(new Tuple<int, int>(2, 12));
            Obstacles.Add(new Tuple<int, int>(3, 1));
            Obstacles.Add(new Tuple<int, int>(3, 3));
            Obstacles.Add(new Tuple<int, int>(3, 7));
            Obstacles.Add(new Tuple<int, int>(3, 9));
            Obstacles.Add(new Tuple<int, int>(3, 10));
            Obstacles.Add(new Tuple<int, int>(4, 2));
            Obstacles.Add(new Tuple<int, int>(4, 9));
            Obstacles.Add(new Tuple<int, int>(6, 7));
            Obstacles.Add(new Tuple<int, int>(9, 7));

            Free.Add(new Tuple<int, int>(1, 1));
            Free.Add(new Tuple<int, int>(1, 2));
            Free.Add(new Tuple<int, int>(1, 3));
            Free.Add(new Tuple<int, int>(1, 4));
            Free.Add(new Tuple<int, int>(1, 6));
            Free.Add(new Tuple<int, int>(1, 7));
            Free.Add(new Tuple<int, int>(1, 8));
            Free.Add(new Tuple<int, int>(1, 9));
            Free.Add(new Tuple<int, int>(1, 10));
            Free.Add(new Tuple<int, int>(1, 11));
            Free.Add(new Tuple<int, int>(2, 1));
            Free.Add(new Tuple<int, int>(2, 3));
            Free.Add(new Tuple<int, int>(2, 4));
            Free.Add(new Tuple<int, int>(2, 5));
            Free.Add(new Tuple<int, int>(2, 6));
            Free.Add(new Tuple<int, int>(2, 7));
            Free.Add(new Tuple<int, int>(2, 8));
            Free.Add(new Tuple<int, int>(2, 9));
            Free.Add(new Tuple<int, int>(2, 10));
            Free.Add(new Tuple<int, int>(2, 11));
            Free.Add(new Tuple<int, int>(3, 2));
            Free.Add(new Tuple<int, int>(3, 4));
            Free.Add(new Tuple<int, int>(3, 5));
            Free.Add(new Tuple<int, int>(3, 6));
            Free.Add(new Tuple<int, int>(3, 8));
            Free.Add(new Tuple<int, int>(3, 11));
            Free.Add(new Tuple<int, int>(3, 12));
            Free.Add(new Tuple<int, int>(4, 1));
            Free.Add(new Tuple<int, int>(4, 3));
            Free.Add(new Tuple<int, int>(4, 4));
            Free.Add(new Tuple<int, int>(4, 5));
            Free.Add(new Tuple<int, int>(4, 6));
            Free.Add(new Tuple<int, int>(4, 7));
            Free.Add(new Tuple<int, int>(4, 8));
            Free.Add(new Tuple<int, int>(4, 10));
            Free.Add(new Tuple<int, int>(4, 11));
            Free.Add(new Tuple<int, int>(4, 12));
            Free.Add(new Tuple<int, int>(5, 1));
            Free.Add(new Tuple<int, int>(5, 2));
            Free.Add(new Tuple<int, int>(5, 3));
            Free.Add(new Tuple<int, int>(5, 4));
            Free.Add(new Tuple<int, int>(5, 5));
            Free.Add(new Tuple<int, int>(5, 6));
            Free.Add(new Tuple<int, int>(5, 7));
            Free.Add(new Tuple<int, int>(5, 8));
            Free.Add(new Tuple<int, int>(5, 9));
            Free.Add(new Tuple<int, int>(5, 10));
            Free.Add(new Tuple<int, int>(5, 11));
            Free.Add(new Tuple<int, int>(6, 5));
            Free.Add(new Tuple<int, int>(6, 6));
            Free.Add(new Tuple<int, int>(6, 8));
            Free.Add(new Tuple<int, int>(7, 5));
            Free.Add(new Tuple<int, int>(7, 6));
            Free.Add(new Tuple<int, int>(7, 7));
            Free.Add(new Tuple<int, int>(7, 8));
            Free.Add(new Tuple<int, int>(8, 5));
            Free.Add(new Tuple<int, int>(8, 6));
            Free.Add(new Tuple<int, int>(8, 7));
            Free.Add(new Tuple<int, int>(8, 8));
            Free.Add(new Tuple<int, int>(9, 5));
            Free.Add(new Tuple<int, int>(9, 6));
            Free.Add(new Tuple<int, int>(9, 8));
            Free.Add(new Tuple<int, int>(10, 6));
            Free.Add(new Tuple<int, int>(10, 7));
            Free.Add(new Tuple<int, int>(10, 8));
        }
        
    }

    public class MapPosition
    {
        public Guid Id { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public PositionType? Type { get; set; }
        public float Reward { get; set; }
        public List<MapPosition> PossibleMovements { get; set; }

        public MapPosition(int line, int column, PositionType? type)
        {
            Id = Guid.NewGuid();
            Line = line;
            Column = column;
            Type = type;

            switch (type)
            {
                case PositionType.Inicial:
                    Reward = 1;
                    break;

                case PositionType.Final:
                    Reward = 100;
                    break;

                case PositionType.Obstacle:
                    Reward = -100;
                    break;

                case PositionType.Free:
                    Reward = 1;
                    break;

                default:
                    Reward = 0;
                    break;
            }
        }
    }
}