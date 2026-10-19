namespace StreamlineTask.Models
{
    public class to_do_list
    {
        public int id { get; set; }
        public String Task { get; set; }
        public String Description { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public to_do_list()
        {

        }

    }

}
