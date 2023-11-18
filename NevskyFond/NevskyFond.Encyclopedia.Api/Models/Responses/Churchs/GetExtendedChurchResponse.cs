namespace NevskyFond.Encyclopedia.Api.Models.Responses.Churchs
{
    public class CommentResponseDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreated { get; set; }
    }

    public class GetExtendedChurchResponseDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreation { get; set; }

        public int CityId { get; set; }
    }

    public class GetExtendedChurchResponse
    {
        public GetExtendedChurchResponseDTO Church { get; set; }
        public IEnumerable<CommentResponseDTO> Comments { get; set; }
    }
}