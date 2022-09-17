namespace CinemaAPI.Data.Dtos.Sessao
{
    public class UpdateSessaoDto
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
    }
}
