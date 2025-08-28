using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFinalClienteApi.Models
{
    /// <summary>
    /// Entidade que representa um Cliente.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único do cliente.
        /// </summary>
        /// <value></value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        /// <value></value>
        [MaxLength(120)]
        public required string Nome { get; set; }
        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <value></value>
        [MaxLength(180)]
        [EmailAddress]
        public required string Email { get; set; }
    }
}