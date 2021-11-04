using System;

namespace projetocsharp
{
    class Finanças
    {
        private double salario, c_luz, c_agua, v_compras, cartao;
        private double tempo, valor, parcelas;
        private string nome, resposta;
        private double Contas()
        {
            return (c_luz + c_agua + v_compras + cartao) - salario;
        }
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

            if (Contas() < 0)
            {
                Console.WriteLine("seu saldo foi negativo, no valor de "+Contas()+", por favor revise seus gastos ");
            }
            else
            {
                Console.WriteLine("Meus parabens!!!.. Seu saldo foi positivo no valor de " + Contas() + "R$, parabens continue assim");
            }
        }
        public void financiamento()
        {
            Console.WriteLine();
            if (Contas() >= 1000)
            {
                Console.WriteLine("deseja realizar um projeto de financiamento>>\nSIM\nNÃO");
                resposta = Console.ReadLine();
                if (resposta == "SIM" || resposta == "sim" || resposta == "Sim")
                {
                    Console.WriteLine("digite o valor do seu financiamto>>");
                    valor = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("digite a quantidade de meses que irá ocorrer o financiamento");
                    tempo = Convert.ToInt32(Console.ReadLine());
                    parcelas = valor / tempo;
                    Console.WriteLine("o valor do seu financiamento do valor de R$" + valor + " é de:\nR$" + parcelas + " em " + tempo + " parcelas");
                }
                else
                {
                    Console.WriteLine("Tudo bem, quem sabe na proxima faremos um financiamnto para voce " + nome);
                }
            }
            
        }
        
          
            

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Finanças obj = new Finanças();
            obj.dividas();
            obj.financiamento();
        }
    }
}
    
