using System;

public class Camion
{

    private int id;
    private double volumenDisponible;
    private double pesoDisponible;
    private Paquete[] paquetes;
    Boolean despachado;
    
    
    public Camion(int pId,double pvolumenDisponible, double ppesoDisponible ) {
        id=pId;
        volumenDisponible=pvolumenDisponible;
        pesoDisponible=ppesoDisponible;    
        despachado=false;
    }

    public int darId(){
        return id;
    }

    public double darVolumen(){
        return volumenDisponible;
    }
    public double darPeso(){
        return pesoDisponible;
    }
    public void agregarPaquetes (Paquete[] pPaquetes){
        paquetes=pPaquetes;
    }
    public void modificarVolumen (double nuevoVolumen){
        volumenDisponible=nuevoVolumen;
    }
    public void modificarPeso(double nuevoPeso){
        pesoDisponible=nuevoPeso;
    }
    public Paquete[] darPaquetes()
    {
        return paquetes;
    }
}
