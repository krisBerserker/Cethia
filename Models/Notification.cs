namespace redestro.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public string Contenu { get; set; }
        public string email { get; set; }
        public int telephone { get; set; }


        public DateTime DateEnvoi { get; set; }

    }
}