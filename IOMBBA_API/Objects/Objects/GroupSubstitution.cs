namespace Objects.Objects
{
    /// <summary>
    /// An object of players lists to facilitate group substitutions.
    /// </summary>
    public class GroupSubstitution
    {
        public int[] HomePlayersOn { get; set; }
        public int[] HomePlayersOff { get; set; }
        public int[] AwayPlayersOn { get; set; }
        public int[] AwayPlayersOff { get; set; }
    }
}
