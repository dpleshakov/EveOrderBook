namespace EveOrderBook
{
    internal readonly struct MarketOrder
    {
        public decimal Price { get; init; }

        public string VolRemaining { get; init; }

        public string TypeID { get; init; }

        public int Range { get; init; }

        public string OrderID { get; init; }

        public string VolEntered { get; init; }

        public string MinVolume { get; init; }

        public bool Bid { get; init; }

        public string IssueDate { get; init; }

        public string Duration { get; init; }

        public string StationID { get; init; }

        public string RegionID { get; init; }

        public string SolarSystemID { get; init; }

        public uint Jumps { get; init; }
    }
}
