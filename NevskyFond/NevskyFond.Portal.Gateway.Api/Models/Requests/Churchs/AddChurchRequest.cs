namespace NevskyFond.Portal.Gateway.Api.Models.Requests.Churchs
{
    /// <summary>
    /// Добавление религиозного учреждения
    /// </summary>
    public class AddChurchRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreation { get; set; }
    }
}