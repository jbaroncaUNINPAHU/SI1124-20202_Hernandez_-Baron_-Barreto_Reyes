using System;

public class Paquete
{

    private int id;
    private double volumen;
    private double peso;
    Boolean ingresado;

    public Paquete(int id,double volumen, double peso ) {
        this.id=id;
        this.volumen=volumen;
        this.peso=peso;
        this.ingresado=false;

    }
    public int darId(){
        return id;
    }
    public double darVolumen(){
        return volumen;
    }
    public double darPeso(){
        return peso;
    }
    public void modificarIngresar(Boolean ingresado)
    {
        this.ingresado=ingresado;
    }
    public Boolean retornarIngresado ()
    {
        return ingresado;
    }
    
}