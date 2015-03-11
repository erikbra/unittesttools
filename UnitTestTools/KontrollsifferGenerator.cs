namespace UnitTestTools
{
    public class KontrollsifferGenerator
    {
        private int[] _weights1 = new[] { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
        private int[] _weights2 = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        public KontrollsifferGenerator()
        {
        }

        public string Generate(string fnr)
        {
            var mod1 = new Modulo11(fnr, _weights1).Calculate();
            var mod2 = new Modulo11(fnr + mod1, _weights2).Calculate();

            return "" + mod1 + mod2;
        }

        public void Validate(string fnr, int kontrollsiffer1, int kontrollsiffer2)
        {
            new Modulo11(fnr, _weights1).Validate(kontrollsiffer1);
            new Modulo11(fnr + kontrollsiffer1, _weights2).Validate(kontrollsiffer2);
        }
    }
}
