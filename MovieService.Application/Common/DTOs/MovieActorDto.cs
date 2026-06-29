namespace MovieService.Application.Common.DTOs
{
    public class MovieActorDto
    {
        public Guid Id {  get; set; }
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public string CharacterName { get; set; }
    }
}
