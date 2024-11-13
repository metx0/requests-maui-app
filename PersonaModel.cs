namespace RequestsApp
{
    public class PersonaModel
    {
        public PersonaModel(string nombre, string apellido, string sexo, string fh_nac, int id_rol)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.fh_nac = fh_nac;
            this.id_rol = id_rol;
        }

        // All the properties defined in the endpoint used to add a person
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string fh_nac { get; set; }
        public int id_rol { get; set; }

        public string nombre_completo
        {
            get => $"{nombre}  {apellido}";
        }

    }
}
