namespace Jira.Models
{
    public class BoardInfo
    {
        public int ID { get; set; }
        public string Self { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public BoardLocationInfo Location { get; set; }
        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }
}
