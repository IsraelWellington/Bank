using System;
public class Conta
{
    private TipoConta TipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
        this.TipoConta=tipoConta;
        this.Saldo=saldo;
        this.Credito=credito;
        this.Nome=nome;
    }
    public Conta(){
        this.TipoConta=0;
        this.Saldo=0;
        this.Credito=0;
        this.Nome=null;
    }

    public bool Sacar(double valorSaque){
        if ( valorSaque > this.Credito + this.Saldo ){
            Console.WriteLine("Saldo insuficiente");
            return false;
        }else{
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;

        }
    }

    public void Depositar (double valorDeposito){
        this.Saldo += valorDeposito;

        Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
    }

    public void Transferir (double valorTransf, Conta contaDestino){
        if(this.Sacar(valorTransf)){
            contaDestino.Depositar(valorTransf);
            }

    }

    public override string ToString(){
        string retorno = "";
        retorno += "TipoConta " + this.TipoConta + " | ";
        retorno += "Nome " + this.Nome + " | ";
        retorno += "Credito " + this.Credito + " | ";
        retorno += "Saldo " + this.Saldo + " | ";
            
        return retorno;
    }
}