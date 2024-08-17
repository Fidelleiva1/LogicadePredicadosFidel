namespace LogicadePredicadosFidel
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Definición de enfermedades
            Enfermedad gripe = new Enfermedad("Gripe");
            Enfermedad covid = new Enfermedad("Covid");
            Enfermedad resfriado = new Enfermedad("Resfriado común");
            Enfermedad neumonia = new Enfermedad("Neumonía");
            Enfermedad alergia = new Enfermedad("Alergia");

            // Definición de síntomas
            Sintoma fiebre = new Sintoma("Fiebre");
            Sintoma tos = new Sintoma("Tos");
            Sintoma dificultadRespirar = new Sintoma("Dificultad para respirar");
            Sintoma estornudos = new Sintoma("Estornudos");
            Sintoma congestionNasal = new Sintoma("Congestión nasal");
            Sintoma dolorCabeza = new Sintoma("Dolor de cabeza");

            // Relacionar síntomas con enfermedades
            RelacionSintomaEnfermedad relaciones = new RelacionSintomaEnfermedad();

            // Relaciones para Gripe
            relaciones.AgregarSintomaEnfermedad(fiebre, gripe);
            relaciones.AgregarSintomaEnfermedad(tos, gripe);
            relaciones.AgregarSintomaEnfermedad(dolorCabeza, gripe);

            // Relaciones para COVID-19
            relaciones.AgregarSintomaEnfermedad(tos, covid);
            relaciones.AgregarSintomaEnfermedad(fiebre, covid);
            relaciones.AgregarSintomaEnfermedad(dificultadRespirar, covid);

            // Relaciones para Resfriado común
            relaciones.AgregarSintomaEnfermedad(estornudos, resfriado);
            relaciones.AgregarSintomaEnfermedad(congestionNasal, resfriado);
            relaciones.AgregarSintomaEnfermedad(dolorCabeza, resfriado);

            // Relaciones para Neumonía
            relaciones.AgregarSintomaEnfermedad(fiebre, neumonia);
            relaciones.AgregarSintomaEnfermedad(tos, neumonia);
            relaciones.AgregarSintomaEnfermedad(dificultadRespirar, neumonia);

            // Relaciones para Alergia
            relaciones.AgregarSintomaEnfermedad(estornudos, alergia);
            relaciones.AgregarSintomaEnfermedad(congestionNasal, alergia);
            relaciones.AgregarSintomaEnfermedad(dolorCabeza, alergia);

            // Verificación de relaciones
            Console.WriteLine($"¿La fiebre es un síntoma de la gripe? {relaciones.EsSintomaDe(fiebre, gripe)}");
            Console.WriteLine($"¿La tos es un síntoma de COVID-19? {relaciones.EsSintomaDe(tos, covid)}");
            Console.WriteLine($"¿Los estornudos son un síntoma de resfriado común? {relaciones.EsSintomaDe(estornudos, resfriado)}");
            Console.WriteLine($"¿La dificultad para respirar es un síntoma de neumonía? {relaciones.EsSintomaDe(dificultadRespirar, neumonia)}");
            Console.WriteLine($"¿La congestión nasal es un síntoma de alergia? {relaciones.EsSintomaDe(congestionNasal, alergia)}");
            Console.WriteLine($"¿El dolor de cabeza es un síntoma de la gripe? {relaciones.EsSintomaDe(dolorCabeza, gripe)}");
            Console.WriteLine($"¿El dolor de cabeza es un síntoma de alergia? {relaciones.EsSintomaDe(dolorCabeza, alergia)}");
        }
    }

    class Enfermedad
    {
        public string Nombre { get; }

        public Enfermedad(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Sintoma
    {
        public string Nombre { get; }

        public Sintoma(string nombre)
        {
            Nombre = nombre;
        }
    }

    class RelacionSintomaEnfermedad
    {
        private List<Tuple<Sintoma, Enfermedad>> relacionesSintomaEnfermedad;

        public RelacionSintomaEnfermedad()
        {
            relacionesSintomaEnfermedad = new List<Tuple<Sintoma, Enfermedad>>();
        }

        public void AgregarSintomaEnfermedad(Sintoma sintoma, Enfermedad enfermedad)
        {
            relacionesSintomaEnfermedad.Add(new Tuple<Sintoma, Enfermedad>(sintoma, enfermedad));
        }

        public bool EsSintomaDe(Sintoma sintoma, Enfermedad enfermedad)
        {
            return relacionesSintomaEnfermedad.Contains(new Tuple<Sintoma, Enfermedad>(sintoma, enfermedad));
        }
    }
}
