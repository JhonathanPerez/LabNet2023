using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo
{
    public class OmniBus : TransportePublico
    {
        public const int MaxPasajeros = 100;
        public int idOminiBus { get; set; }
        public bool enMarcha { get; set; }

        public OmniBus(int NumeroPasajeros, int idOmnibus, bool enMarcha = false)
            : base(NumeroPasajeros)
        {
            this.idOminiBus = idOmnibus;
        }

        public override void Avanzar()
        {
            if (!enMarcha)
            {
                Console.WriteLine($"Soy el Omnibus número {this.idOminiBus} y estoy avanzando");
                this.enMarcha = true;
            }
            else
            {
                Console.WriteLine($"Soy el omniBus número {this.idOminiBus} ya me encuentro en marcha");
            }
        }

        public override void Detenerse()
        {
            if (enMarcha)
            {
                Console.WriteLine($"Soy el Omnibus número {this.idOminiBus} y me estoy detenido");
                this.enMarcha = false;

            }
            else
            {
                Console.WriteLine($"Soy el Omnibus número {this.idOminiBus} ya estoy detenido");
            }
        }

        public static bool ValidarNumeroPasajeros(int Npasajeros)
        {
            return Npasajeros > 0 && Npasajeros <= MaxPasajeros;
        }

        public override void MostrarPasajeros()
        {
            Console.WriteLine(
                $"Soy el OmniBus número {this.idOminiBus} y llevo {this.get_pasajeros()} pasajeros"
            );
        }
    }
}
