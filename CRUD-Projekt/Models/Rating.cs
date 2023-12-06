namespace CRUD_Projekt.Models
{
    public class MyRating
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Rating { get; set; }
    }

}
