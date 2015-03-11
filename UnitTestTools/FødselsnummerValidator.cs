namespace UnitTestTools
{
    public class FødselsnummerValidator
    {
        private readonly KontrollsifferGenerator _kontrollsifferGenerator;

        public FødselsnummerValidator()
        {
            _kontrollsifferGenerator = new KontrollsifferGenerator();
        }

        public void Validate(string fødselsnummer)
        {
            var fnr = fødselsnummer.Substring(0, 9);
            var k1 = int.Parse(fødselsnummer.Substring(9, 1));
            var k2 = int.Parse(fødselsnummer.Substring(10, 1));

            _kontrollsifferGenerator.Validate(fnr, k1, k2);
       }
    }
}
