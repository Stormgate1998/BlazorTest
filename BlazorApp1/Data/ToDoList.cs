namespace BlazorApp1.Data
{
    public class ToDoList
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Due { get; set; }

        public DateTime? CompletetedOn { get; set; }

        public ICollection<ToDoList>? Sublist { get; set; }
    }
}
