using System;

namespace SI1124_2020_hernandez_baron_barreto
{
    class Program
    {
        
        static string pathCamiones="./txt/Camiones.txt";
        static string pathPaquetes="./txt/Paquetes.txt";
        static Paquete [] paquetes;
        static Camion  [] camiones;
        static int cantidadPaquetes=0;
        static int cantidadCamiones=0;


        static void Main(string[] args)
        {
            string[] linesCamiones = System.IO.File.ReadAllLines(pathCamiones);
            cantidadCamiones=linesCamiones.Length - 1;
            camiones=new Camion[cantidadCamiones];
            for(int i=1; i<=cantidadCamiones; i++)
            {
                string lineaActual=linesCamiones[i];
                string [] datosCamion=lineaActual.Split(";");
                int idActual=Int32.Parse(datosCamion[0]);
                double volumenActual=double.Parse(datosCamion[1]);
                double pesoActual=double.Parse(datosCamion[2]);
                Camion camionActual=new Camion (idActual,volumenActual,pesoActual);
                camiones[i-1]=camionActual; 
            }
            string[] linesPaquetes = System.IO.File.ReadAllLines(pathPaquetes);
            cantidadPaquetes=linesPaquetes.Length - 1;
            paquetes=new Paquete[cantidadPaquetes];
            for(int i=1; i<=cantidadPaquetes; i++)
            {
                string lineaActual=linesPaquetes[i];
                string [] datosPaquetes=lineaActual.Split(";");
                int idActualP=Int32.Parse(datosPaquetes[0]);
                double volumenActualP=double.Parse(datosPaquetes[1]);
                double pesoActualP=double.Parse(datosPaquetes[2]);
                Paquete paqueteActual=new Paquete (idActualP,volumenActualP,pesoActualP);
                paquetes[i-1]=paqueteActual;
            }
            for(int i=0; i<camiones.Length; i++)
            {
                Camion ultimoCamion=camiones[i];
                double volumenCamion=ultimoCamion.darVolumen();
                double pesoCamion=ultimoCamion.darPeso();
                Paquete [] paquetesDelCamion;
                int cantidadPaquetesCamion=0;
                for(int j=0; j<paquetes.Length; j++)
                {
                    Paquete paqueteActual=paquetes[j];
                    double volumenDelPaquete=paqueteActual.darVolumen();
                    double pesoDelPaquete=paqueteActual.darPeso();
                    Boolean paqueteCabeEnCamion=volumenDelPaquete<=volumenCamion&&pesoDelPaquete<=pesoCamion;
                    if(paqueteCabeEnCamion==true&&paqueteActual.retornarIngresado()==false)
                    {
                        cantidadPaquetesCamion ++;
                        volumenCamion=volumenCamion-volumenDelPaquete;
                        pesoCamion=pesoCamion-pesoDelPaquete;
                    }
                }
                paquetesDelCamion=new Paquete [cantidadPaquetesCamion];
                int indicePaquetesAgregados=0;
                for(int j=0; j<paquetes.Length; j++)
                {
                    Paquete paqueteActual=paquetes[j];
                    double volumenDelPaquete=paqueteActual.darVolumen();
                    double pesoDelPaquete=paqueteActual.darPeso();
                    Boolean paqueteCabeEnCamion=volumenDelPaquete<=ultimoCamion.darVolumen()&&pesoDelPaquete<=ultimoCamion.darPeso();
                    if(paqueteCabeEnCamion==true&&paqueteActual.retornarIngresado()==false)
                    {
                        paqueteActual.modificarIngresar(true);
                        paquetesDelCamion [indicePaquetesAgregados]=paqueteActual;
                        indicePaquetesAgregados ++;
                        ultimoCamion.modificarVolumen(ultimoCamion.darVolumen()-volumenDelPaquete);
                        ultimoCamion.modificarPeso(ultimoCamion.darPeso()-pesoDelPaquete);
                    }
                }
                ultimoCamion.agregarPaquetes(paquetesDelCamion);
            }
            Console.WriteLine("paquetes no despachados:");
            for(int i=0; i<paquetes.Length; i++)
            {
                if(paquetes[i].retornarIngresado()==false)
                {
                    Console.WriteLine("id: "+paquetes[i].darId()+" volumen: "+paquetes[i].darVolumen()+" peso: "+paquetes[i].darPeso());
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Camiones despachados:");
            for(int i =0; i<camiones.Length; i++)
            {
                Camion camionActual=camiones[i];
                Console.WriteLine("camion - id: "+camionActual.darId()+" volumen restante: "+camionActual.darVolumen()+" peso restante: "+camionActual.darPeso());
                for(int j=0; j<camionActual.darPaquetes().Length; j++)
                {
                    Console.WriteLine("id: "+camionActual.darPaquetes()[j].darId()+" volumen: "+camionActual.darPaquetes()[j].darVolumen()+" peso: "+camionActual.darPaquetes()[j].darPeso());
                }
                Console.WriteLine(" ");
            }
        }
    }
}