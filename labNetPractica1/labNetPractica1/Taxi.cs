﻿using System;
using System.Collections.Generic;

namespace labNetPractica1
{
    public class Taxi : TransportePublico
    {
        public static int maxVehiculos = 5;

        public const int MaxPasajeros = 4;
        public int idTaxi { get; set; }
        public bool enMarcha { get; set; }

        public Taxi(int pasajeros, int idTaxi, bool enMarcha = false)
            : base(pasajeros)
        {
            this.idTaxi = idTaxi;
            this.enMarcha = enMarcha;
            maxVehiculos--;
        }

        public override void Avanzar()
        {
            if (!enMarcha)
            {
                Console.WriteLine($"Soy el taxi número {this.idTaxi} y estoy avanzando");
                this.enMarcha = true;
            }
            else
            {
                Console.WriteLine($"Soy el taxi número {this.idTaxi} ya me encuentro en marcha");
            }
        }

        public override void Detenerse()
        {
            if (enMarcha)
            {
                Console.WriteLine($"Soy el taxi número {this.idTaxi} y me estoy deteniendo");
                this.enMarcha = false;
            }
            else
            {
                Console.WriteLine($"Soy el taxi número {this.idTaxi} ya estoy detenido");
            }
        }

        public static bool ValidarNumeroPasajeros(int Npasajeros)
        {
            return Npasajeros > 0 && Npasajeros <= MaxPasajeros;
        }

        public override void MostrarPasajeros()
        {
            Console.WriteLine(
                $"Soy el taxi número {this.idTaxi} y llevo {this.get_pasajeros()} pasajeros"
            );
        }
    }
}
