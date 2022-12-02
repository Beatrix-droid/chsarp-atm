using System;

namespace dotnetcore;


public class Atm{
    public string name;
    public string surname;
    public double balance;
    private int PIN;
    
    public Atm(string name, string surname, double balance, int PIN){
        //initilaises user
        
        this.name=name;
        this.surname =surname;
        this.balance=balance;
        this.PIN=PIN;
    }

    public string deposit_money (int number, float money){

        if (confirmPin(number)){
            //allows users to deposit money
            this.balance += money;
            string message = $"current balance is {this.balance}";
            return message;}
        else{
            string message= "incorrect pin, unable to perform operation";
            return message;
        }
    }

    public string get_balance(int number){
        if (confirmPin(number)){
            //allows users to see their balance
            string message = $"current balance is {this.balance}";
            return message;
        }
        else{
            string message = "incorrect pin, unable to perform operation";
        return message;
        }
    }

    public string withdraw(int number, float money){
            if (confirmPin(number)){
                if (money >= this.balance){
                    string message = "Unsufficient funds to withdraw";
                    return message;
                }
                else{
                    this.balance= this.balance - money;
                    string message = $"current balance is {this.balance}";
                    return message;
                }
            }
            else{
                string message = "incorrect pin, unable to perform operation";
                return message;
                }}


        public bool confirmPin(int number){
            if (number != this.PIN){
                return false;}
            else{
                return true;
            }
        
        }

        public string change_Pin(int number, int Number_2){
            if (confirmPin(number)){
                this.PIN = Number_2;
                string message = "Pin successfully changed!";
                return message;}
            else{
                string message = "Incorrect Pin, unable to perform operation";
                return message;
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //here create any number of users
            Console.WriteLine("Welcome to this atm amchine. Please enter your card Pin number");
            Console.ReadLine();


            
        }
    }

