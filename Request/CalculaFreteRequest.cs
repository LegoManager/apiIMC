using Microsoft.AspNetCore.Routing.Constraints;

namespace Lista3.Api.Request
{
    public class CalculaFreteRequest
    {
        public string NomeProduto { get; set; } = string.Empty;
        public float PesoProduto {  get; set; } 
        public float AlturaProduto { get; set; }
        public float LarguraProduto { get; set; }
        public float ComprimentoProduto { get; set; }
        public string UF { get; set; } = string.Empty;
    }
}
