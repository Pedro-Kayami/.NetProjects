namespace StudyCrudAPI.Entities
{
    public class DevEvent
    {

        public DevEvent()
        {
            Speakers = new List<DevEventsSpeaker>();
            IsDeleted = false;
        }
        public Guid id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<DevEventsSpeaker> Speakers{ get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
