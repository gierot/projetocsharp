using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetocsharp
{
    class Contas
    {
        private double salario, c_luz, c_agua, v_compras, cartao;
        public double valorTotal;
        protected string nome;

        public void dividas()
        {
            Console.WriteLine("digite o seu nome por favor>>");
            nome = Console.ReadLine();
            Console.WriteLine("Ola " + nome + ", seu ajudante financeiro pessoal entrárá em ação!!\nMas antes temos que recolher algumas informações suas\nEntão para começarmos responda cada pergunta com o equivalente valor, caso não haja valor digite 0");
            Console.WriteLine();
            Console.WriteLine("informe o seu salario>>");
            salario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o valor da sua conta de agua>>");
            c_agua = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o valor da sua conta de luz>>");
            c_luz = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o valor total das suas compras>>");
            v_compras = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o valor pago no cartão");
            cartao = Convert.ToInt32(Console.ReadLine());
            valorTotal = salario - (c_luz + c_agua + v_compras + cartao);

            if (valorTotal < 0)
            {
                Console.WriteLine("seu saldo foi negativo, no valor de " + valorTotal + ", por favor revise seus gastos ");
            }
            else
            {
                Console.WriteLine("Meus parabens!!!.. Seu saldo foi positivo no valor de R$" + valorTotal + "\nParabens continue assim!!!");
            }
            
        }
        public double ValorTotal
        {
            get { return valorTotal; }
        }


    }
    class Financiamento : Contas
    {

        protected double valor;
        private int tempo;
        private double entrada;
        protected double capitalRestante;

        public void Financ()
        {
            this.dividas();
            Console.WriteLine("deseja realizar um projeto de financiamento>>\nSIM\nou NÃO?");
            string resposta = Console.ReadLine();
            List<double> fina = new List<double>();
            if (resposta == "Sim" || resposta == "sim")
            {
                Console.WriteLine("digite o valor do seu financiamto>>");
                valor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("digite o valor da entrada que voce pagará\nCaso não dando entrada o valor será totalemte financiado");
                entrada = double.Parse(Console.ReadLine());
                Console.WriteLine("digite a quantidade de ano(s) que irá ocorrer o financiamento");
                tempo = Convert.ToInt32(Console.ReadLine());
                double calculo = Math.Pow(1 + 0.0066, tempo * 12);
                double acumulo = 0.0066 / (1 - (1 / calculo));
                fina.Add(acumulo);
                capitalRestante = valorTotal - Math.Round(fina[0] * (valor - entrada));
                Console.WriteLine("O valor da sua parcela será de :");
                Console.WriteLine(Math.Round(fina[0] * (valor - entrada), 2));
                Console.WriteLine(valorTotal);
            }
            else
            {
                Console.WriteLine("Tudo bem " + nome + " quem sabe na proxima, podemos fazer um financiamento para você");
            }
        }
    }
    class Poupança : Financiamento
    {
        private double quantia;
        private double juros;
        private int tempo;
        private double rendimento, diferença;

        public void poupanca()
        {
            
            if (capitalRestante > 0)
            {
                Console.WriteLine("voce deseja depositar algum valor em sua poupança>>\nsim\nou não?");
                string respost = Console.ReadLine();
                if (respost == "sim" || respost == "Sim" || respost == "SIM")
                {

                    List<double> poup = new List<double>();
                    Console.WriteLine("insira a quantia que você depositará na sua poupança");
                    quantia = double.Parse(Console.ReadLine());
                    Console.WriteLine("insira em quantos meses será aplicado o seu dinheiro");
                    tempo = Convert.ToInt32(Console.ReadLine());
                    juros = Math.Pow(1 + 0.0062, tempo);
                    rendimento = (quantia * (juros - 1)) / 0.0062;
                    poup.Add(rendimento);
                    diferença = capitalRestante - quantia;
                    Console.WriteLine("o valor da sua poupança no proximo mês será de ");
                    Console.WriteLine("R$" + Math.Round(poup[0] / tempo, 2) + "\nUm rendimento de R$" + Math.Round(poup[0] / 12 - quantia, 2));
                    Console.WriteLine("sua conta depois desse deposito esta com R$" + Math.Round(diferença, 2));

                }
                else
                {
                    Console.WriteLine("tudo bem voce ainda tem R$" + Math.Round(capitalRestante, 2) + ", ma sua conta\nTenha controle do seu dinheiro e até a proxima");
                }
            }
            else
            {
                Console.WriteLine("Ops!! você não possui capital suficiente para investir na sua poupança....\nPor favor reveja seus gastos.");
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
                

            }


        }
    }


}

