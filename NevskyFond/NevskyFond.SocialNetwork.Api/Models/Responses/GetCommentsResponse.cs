namespace NevskyFond.SocialNetwork.Api.Models.Responses
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

        /// <summary>
        /// ID религиозного учреждения
        /// </summary>
        public int ChurchId { get; set; }
    }

    public class GetCommentsResponse
    {
        public IEnumerable<CommentResponseDTO> Comments { get; set; }
    }
}
