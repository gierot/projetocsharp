using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetocsharp
{
    class Contas
    {
        private double salario, c_luz, c_agua, v_compras, cartao;
        private double ValorTotal;
        protected string nome;
        
        public void dividas()
        {
            Console.Write("digite o seu nome por favor: ");
            nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ola " + nome + ", seu ajudante financeiro pessoal entrárá em ação!!\nMas antes temos que recolher algumas informações suas\nEntão para começarmos responda cada pergunta com o equivalente valor, caso não haja valor digite 0");
            Console.WriteLine();
            Console.Write("informe o seu salario: R$");
            salario = Convert.ToInt32(Console.ReadLine());
            Console.Write("digite o valor da sua conta de agua: R$");
            c_agua = Convert.ToInt32(Console.ReadLine());
            Console.Write("digite o valor da sua conta de luz: R$");
            c_luz = Convert.ToInt32(Console.ReadLine());
            Console.Write("digite o valor total das suas compras: R$");
            v_compras = Convert.ToInt32(Console.ReadLine());
            Console.Write("digite o valor pago no cartão: R$");
            cartao = Convert.ToInt32(Console.ReadLine());
            ValorTotal = salario - (c_luz + c_agua + v_compras + cartao);

            if (ValorTotal < 0)
            {
                Console.WriteLine("seu saldo foi negativo, no valor de " + ValorTotal + ", por favor revise seus gastos ");
            }
            else
            {
                Console.WriteLine("Meus parabens!!!.. Seu saldo foi positivo no valor de R$" + ValorTotal + "\nParabens continue assim!!!");
            }
        }           
    }
    class Financiamento : Contas
    {
        protected double valor;
        private int tempo;
        private double entrada;        
        public void Financ()
        {
            
            Console.WriteLine("deseja realizar um projeto de financiamento>>\nSIM\nou NÃO?");
            string resposta = Console.ReadLine();
            List<double> fina = new List<double>();
            if (resposta == "Sim" || resposta == "sim")
            {
                Console.Write("digite o valor do seu financiamto: R$");
                valor = Convert.ToInt32(Console.ReadLine());
                Console.Write("digite o valor da entrada que voce pagará\nCaso não dando entrada o valor será totalmente financiado ");
                entrada = double.Parse(Console.ReadLine());
                Console.Write("digite a quantidade de ano(s) que irá ocorrer o financiamento ");
                tempo = Convert.ToInt32(Console.ReadLine());
                double calculo = Math.Pow(1 + 0.0066, tempo * 12);
                double acumulo = 0.0066 / (1 - (1 / calculo));
                fina.Add(acumulo);
                Console.WriteLine("O valor da sua parcela será de :");
                Console.WriteLine(Math.Round(fina[0] * (valor - entrada), 2));
            }
            else
            {
                Console.WriteLine("Tudo bem quem sabe na proxima, podemos fazer um financiamento para você");
            }
        }
    }
    class Poupança 
    {
        private double quantia;
        private double juros;
        private int tempo;
        private double rendimento;
        public void poupanca()
        {
            Console.Write("voce deseja depositar algum valor em sua poupança>>\nsim ou não? ");
            string respost = Console.ReadLine();
            if (respost == "sim" || respost == "Sim" || respost == "SIM")
            {
                List<double> poup = new List<double>();
                Console.Write("insira a quantia que você depositará na sua poupança R$");
                quantia = double.Parse(Console.ReadLine());
                Console.Write("insira em quantos meses será aplicado o seu dinheiro ");
                tempo = Convert.ToInt32(Console.ReadLine());
                juros = Math.Pow(1 + 0.0062, tempo);
                rendimento = (quantia * (juros - 1)) / 0.0062;
                double restante = (rendimento / tempo) - quantia;
                poup.Add(rendimento);
                Console.WriteLine("o valor da sua poupança daqui a "+tempo+" meses será de: ");
                Console.WriteLine("R$" + Math.Round(poup[0] / tempo, 2) + "\nUm rendimento de R$" + Math.Round(restante, 2));

            }
            else
            {
                Console.WriteLine("Tudo bem!!!\nQuem sabe na proxima...");
            }                                     
        }
        class Program
        {
            static void Main(string[] args)
            {
                Contas obj = new Contas();
                Financiamento tst = new Financiamento();
                Poupança pop = new Poupança();
                obj.dividas();
                tst.Financ();
                pop.poupanca();
            }
        }
    }
}
