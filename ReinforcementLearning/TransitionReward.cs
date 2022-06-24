namespace ReinforcementLearning
{
    public class TransitionReward
    {
        public MapPosition OriginalPosition { get; set; }
        public MapPosition TargetPosition { get; set; }
        public string OriginalPositionCoordenates => $"L{OriginalPosition.Line}:C{OriginalPosition.Column}";
        public string TargetPositionCoordenates => $"L{TargetPosition.Line}:C{TargetPosition.Column}";
        public float Reward { get; set; }

        private TransitionReward(MapPosition originalPosition, MapPosition targetPosition)
        {
            OriginalPosition = originalPosition;
            TargetPosition = targetPosition;
        }

        public static List<TransitionReward> GenerateQTable(Map map)
        {
            var qTable = new List<TransitionReward>();
            foreach (var position in map.Positions)
            {
                foreach (var possibleMovement in position.PossibleMovements)
                {
                    qTable.Add(new TransitionReward(position, possibleMovement));
                }
            }
            return qTable;
        }
    }
}
