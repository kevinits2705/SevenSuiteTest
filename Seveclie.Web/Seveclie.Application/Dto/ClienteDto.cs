public class ClienteDto
{
    public int IdCliente { get; set; }
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public string FechaNacimiento { get; set; }

    public int EstadoCivilId { get; set; }
    public string EstadoCivil { get; set; }
}
