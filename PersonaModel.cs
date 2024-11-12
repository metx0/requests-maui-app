namespace RequestsApp
{
    public class PersonaModel
    {
        // All the properties defined in the endpoint used to add a person
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string fh_nac { get; set; }
        public string id_rol { get; set; }
    }
}
