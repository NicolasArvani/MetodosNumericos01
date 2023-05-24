

namespace MetodosNumericos01{
    public class RegressaoLinear{
        private double[] x;
        private double[] y;
        private double a;
        private double b;
       

        public RegressaoLinear(double[] x, double[] y){
            this.x = x;
            this.y = y;
            this.calcRegressaoLinear();
        }


        public void print(){
            Console.WriteLine("x\t| y");
            Console.WriteLine("-------------");
            for (int i = 0; i < this.x.Length; i++){
                Console.WriteLine(this.x[i] + "\t| " + this.y[i]);
            }
            Console.WriteLine("a = " + this.a);
            Console.WriteLine("b = " + this.b);
        }

        private void calcRegressaoLinear(){
            double n = this.x.Length;
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumX2 = 0;
            for (int i = 0; i < n; i++){
                sumX += this.x[i];
                sumY += this.y[i];
                sumXY += this.x[i] * this.y[i];
                sumX2 += this.x[i] * this.x[i];
            }
            this.b = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            this.a = (sumY - this.b * sumX) / n;
            
        }

        public String getEquacaoReta(){

            return this.a + (this.b >= 0 ? "+" : "") + this.b + "*x";
        }
    }
}