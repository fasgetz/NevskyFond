namespace NevskyFond.Encyclopedia.Api.Models.Responses.Churchs
{
    public class ChurchResponseDTO
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

    public class GetChurchByIdResponse
    {
        public ChurchResponseDTO Church { get; set; }
    }
}
