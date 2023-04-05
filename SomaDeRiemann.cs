using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class SomaDeRiemann
    {
        private Funcao funcao { get; set; }
        private double inicio { get; set; }
        private double fim { get; set; }


        public SomaDeRiemann(String funcao, double inicio, double fim)
        {
            this.funcao = new Funcao(funcao);
            this.inicio = inicio;
            this.fim = fim;
        }
        
        public SomaDeRiemann(String funcao)
        {
            this.funcao = new Funcao(funcao);
        }

        public double calcArea(int divisoes)
        {
            double area = 0;
            double Base = (this.fim - this.inicio) / divisoes;
            double mid = Base / 2;
                        
            for(int i = 0; i < divisoes; i++)
            {
                area += Base * funcao.calculaY(this.inicio + Base * i + mid);
            }  

            return area;
        }

    }
}
