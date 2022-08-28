namespace WebAPI.Entities
{
    public class ContactoCliente
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set;  }
        public string Mensaje { get; set; }
       
    }
}
