
using System.Text.Json.Serialization;

namespace Domain.Models.DetallePedido
{
    public class SaveDetallePedidoModel
    {
        public int IdPedido { get; set; }

        [JsonIgnore]
        public int IdDelPlato { get; set; }

        public string NombrePlato { get; set; }
        
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

    }
}
