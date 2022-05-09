using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Book
    {
        
            protected string name;
            protected string author_name;
            protected string publication_date;
            protected double price;
            public double Rent_price;
            public double Purchase_price;
            protected int quantity;
            protected string publisher;
            protected int Borrow;
            protected int Bought;
            protected int State;
            protected int Access;
            public Book()
            {

            }
            public Book(string name, string author_name, string publication_date, double price, int quantity, string publisher, double Rent_price, double Purchase_price, int Borrow, int Bought, int State, int Access)
            {
                this.name = name;
                this.author_name = author_name;
                this.publication_date = publication_date;
                this.price = price;
                this.quantity = quantity;
                this.publisher = publisher;
                this.Rent_price = Rent_price;
                this.Purchase_price = Purchase_price;
                this.Borrow = Borrow;
                this.Bought = Bought;
                this.State = State;
                this.Access = Access;

            }

            public string Name
            {
                set { name = value; }
                get { return name; }
            }

            public string Author_name
            {
                set { author_name = value; }
                get { return author_name; }
            }

            public string Publication_date
            {
                set { publication_date = value; }
                get { return publication_date; }
            }


            public double Price
            {
                set { price = value; }
                get { return price; }
            }

            public int Quantity
            {
                set { quantity = value; }
                get { return quantity; }
            }

            public string Publisher
            {
                set { publisher = value; }
                get { return publisher; }
            }

        public double rent_price
        {
            set { Rent_price = value; }
            get { return Rent_price; }
        }

        public double purchase_price
        {
            set { Purchase_price = value; }
            get { return Purchase_price; }
        }

        public int borrow
        {
            set { Borrow = value; }
            get { return Borrow; }
        }

        public int bought
        {
            set { Bought = value; }
            get { return Bought; }
        }

        public int state
        {
            set { State = value; }
            get { return State; }
        }

        public int access
        {
            set { Access = value; }
            get { return Access; }
        }

        public static string Search(string target, List<Book> book, int size)
            {

                for (int i = 0; i < size; i++)
                {
                    if (target == book[i].Name)
                    {
                        return book[i].ToString();
                    }

                }
                return "Book not found";
            }

            public override string ToString()
            {
                return "Name: " + name + "\n" + "Author name: " + author_name + "\n" + "Publication date: " + publication_date + "\n" +
                    "Price: " + price + "\n" + "Quantity: " + quantity + " (" + borrow + ")" + "\n" + "Publisher: " + publisher + "\n" + "Rent price: " + Rent_price + "\n" + "Purchase price: " + Purchase_price + "\n" + "Access: " + Access + "\n" + "State: " + State;
            }
        
    }
}
