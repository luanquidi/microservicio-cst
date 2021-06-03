namespace Servicios.Api.Cst.Core.Utils
{
    public class RespuestaOperacion<T>
    {
        public T Datos { get; set; }
        public bool ResultadoExitoso { get; set; }
        public string Mensaje{ get; set; }
    }
}
