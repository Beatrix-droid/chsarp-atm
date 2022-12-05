using System;
using System.Collections.Generic;
namespace dotnetcore;
using System.Linq;

public class Atm{
    public string name;
    public string surname;
    public double balance;
    public int PIN;
    
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


        //create the list of users
    
        static void Main(string[] args)
        {
             //create the list of users
            List<Atm> clients = new List<Atm>();

            Atm user_1 = new Atm("John", "DOE", 3200, 1234);
            Atm user_2 = new Atm("Joe", "smith", 400.50, 16634);

            Atm user_3 = new Atm("Pat", "rick", 33.75, 329);
    
            clients.Add(user_1);
            clients.Add(user_2);
            clients.Add(user_3);


            //here create any number of users
            Console.WriteLine("Welcome to this atm machine. Please enter your firstname");

            string first_name = Console.ReadLine();

            Console.WriteLine("Please enter your surname:");

            string last_name = Console.ReadLine();

            bool UserExists = clients.Any(x=> x.name==first_name && x.surname== last_name); 

            if (UserExists){
                Console.WriteLine("User has been found! Please enter your PIN  number to perform an operation with this atm");
                int number = Convert.ToInt32(Console.ReadLine());
                if (UserExists = clients.Any(x=> x.name==first_name && x.surname== last_name && x.PIN==number)){
                        
                        Atm found_user = clients.Find(x=> x.name==first_name && x.surname== last_name && x.PIN==number);

                        bool done = false;

                    

                        Console.WriteLine("PIN was entered correctly. Press 1 to view your balance, 2 to make a deposit, 3 to withdraw, or 4 to change your PIN.");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch(choice){

                                case 1:
                                    Console.WriteLine(found_user.get_balance(number));
                                    break;
                        
                                case 2:
                                    
                                    Console.WriteLine("Please enter the amount you wish to deposit:");
                                    float deposit_money = float.Parse(Console.ReadLine());
                                    Console.WriteLine(found_user.deposit_money(number, deposit_money));
                                    break;
                                case 3:
                                    
                                    Console.WriteLine("Please enter the ammount you wish to withdraw:");
                                    float money = float.Parse(Console.ReadLine());
                                    Console.WriteLine(found_user.withdraw(number, money));
                                    break;
                                
                                case 4:
                                    Console.WriteLine("Please enter the new pin:");
                                    int new_pin = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine(found_user.change_Pin(number, new_pin));
                                    break;
                                
                                default:
                                    Console.WriteLine("number entered is out of range. Press 1 to view your balance, 2 to make a deposit, 3 to withdraw, or 4 to change your PIN. ");
                                    break;
                        }
                }
                else{
                    Console.WriteLine("Pin entered incorrecty. Unable to continue with the operation");
                }
            }
            else{
                Console.WriteLine("Sorry, your credentials were not found in the database. Please make sure you entered the data correctly.");
            }
            
        }
        
    }

